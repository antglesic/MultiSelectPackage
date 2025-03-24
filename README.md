# MultiSelectPackage

A lightweight, customizable Multiselect component built with Blazor. Easily select multiple options from a dropdown with support for search, custom templates, and more.

✨ Features

    ✅ Select multiple options from a dropdown

    🔍 Optional search/filter support

    🎨 Customizable item templates

    🧩 Supports binding to complex data types


🚀 Getting Started
Installation

dotnet add package YourComponentNamespace --version x.x.x

    Or add the project as a reference if you're including it directly.

Usage

<MultiSelect TValue="string"
             Items="@myItems"
             SelectedItems="@selectedItems"
             Placeholder="Select options..." />

Parameters
Parameter	Type	Description
Items	IEnumerable<T>	The list of items to select from
SelectedItems	List<T>	The currently selected items
Placeholder	string	Placeholder text for the dropdown
ItemTemplate	RenderFragment<T>	Optional template for rendering items
Disabled	bool	Disable the component