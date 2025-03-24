# MultiSelectPackage

A lightweight, customizable Multiselect component built with Blazor. Easily select multiple options from a dropdown with support for search, custom templates, and more.

✨ Features

    ✅ Select multiple options from a dropdown

    🔍 Optional search/filter support

    🎨 Customizable item templates

    🧩 Supports binding to complex data types


🚀 Getting Started
## Installation
1. Add the following to your `_Imports.razor` file:
    ```csharp
    @using MultiSelectPackage
    ```
## Usage
See the project `MultiSelectPackage` for more examples of how to use the component

### MultiSelect dropdown
<MultiSelect TValue="string"
             Items="@myItems"
             SelectedItems="@selectedItems"
             Placeholder="Select options..." />
