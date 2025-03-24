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
    @using MultiSelectPackage.Components
    ```
## Usage
See the project `MultiSelectPackage` for more examples of how to use the component

### MultiSelect dropdown
```csharp
<MultiSelect T="DummyDataDto"
	Items="DummyData"
	DisplayProperty="FullName"
	IdentifierProperty="Id"
	ValuesChanged="OnSelectedItemsChanged"
	CanSearch="true"
	SearchPlaceHolder="Search..."
	CustomStyle=""
	Width="35%" />
```

#### When your Item looks like this:
```csharp
public class DummyDataDto
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Surname { get; set; } = string.Empty;
	public string FullName
	{
		get
		{
			return $"{Name} {Surname}";
		}
	}
}
```

#### And your OnSelectedItemsChanged method looks like this:

```csharp
public void OnSelectedItemsChanged(List<DummyDataDto> items)
{
	try
	{
		selectedItems = items;
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
}
```
## Screenshots

### Dropdown closed
![Dropdown closed](https://github.com/user-attachments/assets/52b62d27-8cb5-4dfd-b01f-21089f3f2d27)

### Dropdown opened
![Dropdown opened](https://github.com/user-attachments/assets/4456a168-d161-481c-9579-16badcca7208)

### Dropdown with selected items
![Dropdown selected items](https://github.com/user-attachments/assets/b700618c-0e52-4305-a6aa-1e614b23488c)

### Dropdown with filtered items #1
![Dropdown filtered 1](https://github.com/user-attachments/assets/78dd2dfc-1d3a-47de-80fa-650e79059beb)

### Dropdown with filtered items #2
![Dropdown filtered 2](https://github.com/user-attachments/assets/d3318230-5b14-4e92-bdc4-32da29a884ff)

### Dropdown functionality to remove selected items
![Dropdown remove item](https://github.com/user-attachments/assets/ebc73031-2e90-4b8a-9ed6-2da623a60ee4)
