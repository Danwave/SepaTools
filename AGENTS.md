# Instrucciones para agentes — SepaTools

## Explorar el código: `graphify` antes de barrer con `grep`

El repositorio lleva un **grafo de conocimiento** en `graphify-out/`. Para una pregunta amplia —quién
llama a X, qué se rompe si toco Y, por dónde pasa un flujo— consúltalo antes de encadenar `grep` y
lecturas: da la lista completa de llamadores en una sola llamada.

**Actualízalo antes de usarlo.** No hay hooks instalados, así que el grafo solo avanza cuando alguien
lanza el comando, y uno desfasado engaña dos veces: los símbolos añadidos después "no existen", y los
`fichero:Lnnn` que devuelve son los del commit con el que se construyó, así que apuntan a código que
ya se ha movido. La reextracción es determinista y no gasta LLM (cubre código, no documentos):

```powershell
graphify update .    # reescribe graph.json, manifest.json, GRAPH_REPORT.md y graph.html
```

De qué commit viene el grafo: campo `built_at_commit` en la raíz de `graph.json`.

```powershell
graphify explain "<Símbolo>"                          # vecindario del nodo: entrantes, salientes, fichero y línea
graphify affected "<id>" --relation calls --depth 1   # quién lo llama / qué se ve afectado
graphify path "<idA>" "<idB>"                         # camino más corto entre dos símbolos
graphify god-nodes --top 20                           # hubs arquitectónicos
graphify query "<pregunta>"                           # travesía a partir de una pregunta en lenguaje natural
```

- **Resolver el id es medio trabajo.** Si la etiqueta es única basta con ella; si se repite, `explain`
  responde `Ambiguous:` y te imprime los ids candidatos, mientras que `affected` solo dice `No unique
  node match`, así que saca antes el id con `explain`. El id de un método es el de su clase más el
  nombre en minúsculas. Pasar la ruta de un fichero devuelve el nodo *fichero*, no el de la clase.
- **`graphify query` rinde mal en grafos grandes** (más de ~10.000 nodos): trunca por presupuesto de
  tokens y devuelve ruido. Ahí prefiere `explain` y `affected`.
- **Para lo que la CLI no dé, ataca el JSON.** Viene indentado, así que `grep` va fino:
  `grep -B8 '"norm_label": "<clase-en-minúsculas>"' graphify-out/graph.json | grep '"id"'` lista los
  candidatos. Para recorridos, `Get-Content graphify-out\graph.json -Raw | ConvertFrom-Json` deja
  `.nodes` y `.links` como objetos. Los nodos traen `id` (lo que pide `affected`), `label`,
  `norm_label`, `source_file`, `source_location`, `community` y `file_type`; los enlaces tienen
  `relation`: los frecuentes son `calls`, `references`, `method`, `contains` e `imports`, y para
  jerarquías están `inherits`, `implements` y `extends`.
- **El grafo complementa a `grep`, no lo sustituye.** Solo extrae símbolos, llamadas y referencias: no
  ve asignaciones a propiedades ni literales, así que "quién escribe tal campo" sigue siendo un
  `grep`. Contrasta con el código antes de concluir.
- **Excepción a "no incluyas archivos generados en los commits": el grafo sí se versiona**, porque es
  el índice del que parten los agentes. Solo se ignoran `graphify-out/cache/` y las copias de
  seguridad con fecha que deja la reextracción. Sube los ficheros juntos (`git add graphify-out/`) y
  en un commit aparte de los cambios funcionales.
- `graphify-out/GRAPH_REPORT.md` resume comunidades, hubs y conexiones sorprendentes: es el mapa de
  partida cuando aterrizas en una zona del código que no conoces.

## Mutation testing obligatorio al escribir tests

Siempre que escribas o modifiques tests, mide su calidad con mutación antes de cerrar el cambio. La
cobertura no vale para esto: un test puede ejecutar una línea sin comprobar nada. La herramienta
introduce mutaciones en el código (invierte condiciones, cambia operadores, vacía métodos) y comprueba
si algún test falla; el porcentaje de mutantes matados es la medida real de si la suite te protege.

**Veredicto, igual en todos los lenguajes:** **≥80 %** los tests protegen el fichero; **60–80 %** mata
los supervivientes antes de seguir; **<60 %** los tests no protegen y el cambio pasa a ser un PR de
solo tests. No persigas el 100 %: hay mutantes equivalentes (los bordes `<=`/`<` contra la hora actual
son indistinguibles sin un reloj inyectable); cuando un superviviente sea equivalente, dilo en el PR y
sigue.

**Acota siempre la mutación** a los ficheros que tus tests ejercitan. Mutar un proyecto entero
recompila y ejecuta la suite una vez por mutante, y tarda horas.

### C# — Stryker.NET

```powershell
dotnet tool install -g dotnet-stryker     # una vez por máquina

cd <carpeta-del-proyecto-de-test>
dotnet stryker `
    --project <proyecto-a-mutar>.csproj `
    --mutate "**/<FicheroBajoTest>.cs" `
    --reporter progress --reporter html
```

- Stryker resuelve por **referencias de proyecto directas**: el `.csproj` de test debe referenciar
  directamente el proyecto a mutar aunque ya le llegue de forma transitiva. Mantén el patrón al crear
  proyectos de test nuevos.
- Revisa los supervivientes en `StrykerOutput/**/reports/mutation-report.html` y mata cada uno con un
  assert o un caso nuevo.
- Cuidado con los dobles de base de datos en memoria que guardan referencias vivas: releer la entidad
  tras la acción devuelve el mismo objeto ya mutado y **no demuestra que se persistió**. Observa la
  escritura por un campo centinela (`LastUpdate` reseteado antes de actuar) y afirma sobre él.
