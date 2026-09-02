# Graph Report - Danwave__SepaTools  (2026-09-02)

## Corpus Check
- 30 files · ~8,628 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 201 nodes · 291 edges · 15 communities (11 shown, 2 thin omitted)
- Extraction: 93% EXTRACTED · 7% INFERRED · 0% AMBIGUOUS · INFERRED: 19 edges (avg confidence: 0.84)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `d1de27c6`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- .GeneratePaymentInformation
- SepaTransfer
- FinancialFileFormats.SEPA
- SepaIbanData
- Form1
- SepaDebitTransfer
- Resources
- Form1.cs
- XmlValidator
- SepaRuleException
- Instrucciones para agentes — SepaTools
- SepaSequenceTypeUtils
- XmlElementExtension.cs

## God Nodes (most connected - your core abstractions)
1. `SepaTransfer` - 25 edges
2. `Form1` - 23 edges
3. `SepaDebitTransfer` - 18 edges
4. `SepaIbanData` - 16 edges
5. `SepaDebitTransferTransaction` - 15 edges
6. `FinancialFileFormats.SEPA` - 13 edges
7. `SepaCreditTransfer` - 12 edges
8. `SepaTransferTransaction` - 12 edges
9. `FinancialFileFormats.SEPA.Utils` - 11 edges
10. `SepaSchema` - 9 edges

## Surprising Connections (you probably didn't know these)
- `Form1` --references--> `SepaDebitTransfer`  [EXTRACTED]
  Sepa Tools Windows/Form1.Designer.cs → SepaWriter/SepaDebitTransfer.cs
- `SepaCreditTransfer` --references--> `SepaCreditTransferTransaction`  [EXTRACTED]
  SepaWriter/SepaCreditTransfer.cs → SepaWriter/SepaCreditTransferTransaction.cs
- `SepaCreditTransfer` --references--> `SepaIbanData`  [EXTRACTED]
  SepaWriter/SepaCreditTransfer.cs → SepaWriter/SepaIbanData.cs
- `SepaCreditTransfer` --inherits--> `SepaTransfer`  [EXTRACTED]
  SepaWriter/SepaCreditTransfer.cs → SepaWriter/SepaTransfer.cs
- `SepaDebitTransfer` --references--> `SepaIbanData`  [EXTRACTED]
  SepaWriter/SepaDebitTransfer.cs → SepaWriter/SepaIbanData.cs

## Import Cycles
- None detected.

## Communities (15 total, 2 thin omitted)

### Community 0 - ".GeneratePaymentInformation"
Cohesion: 0.12
Nodes (13): XmlDocument, XmlElement, XmlDocument, XmlElement, SepaSchema, DateTime, Regex, StringUtils (+5 more)

### Community 1 - "SepaTransfer"
Cohesion: 0.08
Nodes (20): List, SepaSchema, Pain00100103, Pain00100104, Pain00800102, Pain00800103, DateTime, XmlDocument (+12 more)

### Community 2 - "FinancialFileFormats.SEPA"
Cohesion: 0.09
Nodes (15): FinancialFileFormats.SEPA.Utils, FinancialFileFormats.SEPA, Constant, SepaCreditTransfer, Debtor, DebtorAccountCurrency, SepaPaymentNormalization, SepaD (+7 more)

### Community 3 - "SepaIbanData"
Cohesion: 0.11
Nodes (17): ICloneable, SepaCreditTransferTransaction, Creditor, Regex, SepaIbanData, Bic, Iban, IsValid (+9 more)

### Community 4 - "Form1"
Cohesion: 0.18
Nodes (13): Button, DataGridView, DateTimePicker, EventArgs, Form, GroupBox, IContainer, Label (+5 more)

### Community 5 - "SepaDebitTransfer"
Cohesion: 0.15
Nodes (11): IEnumerable, SepaDebitTransfer, Creditor, CreditorAccountCurrency, PersonId, DateTime, SepaDebitTransferTransaction, DateOfSignature (+3 more)

### Community 6 - "Resources"
Cohesion: 0.15
Nodes (11): ApplicationSettingsBase, Bitmap, Sepa_Tools_Windows.Properties, CultureInfo, ResourceManager, Resources, _1480788634_Gnome_Edit_Paste_64, Culture (+3 more)

### Community 7 - "Form1.cs"
Cohesion: 0.17
Nodes (6): SepaTools, Program, Sepa Tools Windows, net7.0, net7.0, STAThread

### Community 8 - "XmlValidator"
Cohesion: 0.20
Nodes (7): Dictionary, ILog, SepaSchema, XmlNode, XmlValidator, ValidationEventArgs, XmlSchema

### Community 9 - "SepaRuleException"
Cohesion: 0.24
Nodes (3): Exception, SepaRuleException, IbanValidationUtils

### Community 10 - "Instrucciones para agentes — SepaTools"
Cohesion: 0.40
Nodes (4): C# — Stryker.NET, Explorar el código: `graphify` antes de barrer con `grep`, Instrucciones para agentes — SepaTools, Mutation testing obligatorio al escribir tests

## Knowledge Gaps
- **51 isolated node(s):** `ResourceManager`, `Culture`, `_1480788634_Gnome_Edit_Paste_64`, `Default`, `net7.0` (+46 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 83 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **2 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `SepaDebitTransfer` connect `SepaDebitTransfer` to `.GeneratePaymentInformation`, `SepaTransfer`, `FinancialFileFormats.SEPA`, `SepaIbanData`, `Form1`, `SepaRuleException`?**
  _High betweenness centrality (0.315) - this node is a cross-community bridge._
- **Why does `Form1` connect `Form1` to `SepaTransfer`, `SepaDebitTransfer`, `Form1.cs`?**
  _High betweenness centrality (0.206) - this node is a cross-community bridge._
- **Why does `SepaTransfer` connect `SepaTransfer` to `SepaRuleException`, `FinancialFileFormats.SEPA`, `SepaIbanData`, `SepaDebitTransfer`?**
  _High betweenness centrality (0.195) - this node is a cross-community bridge._
- **What connects `ResourceManager`, `Culture`, `_1480788634_Gnome_Edit_Paste_64` to the rest of the system?**
  _51 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `.GeneratePaymentInformation` be split into smaller, more focused modules?**
  _Cohesion score 0.1164021164021164 - nodes in this community are weakly interconnected._
- **Should `SepaTransfer` be split into smaller, more focused modules?**
  _Cohesion score 0.08262108262108261 - nodes in this community are weakly interconnected._
- **Should `FinancialFileFormats.SEPA` be split into smaller, more focused modules?**
  _Cohesion score 0.08923076923076922 - nodes in this community are weakly interconnected._