﻿using Microsoft.AspNetCore.Components;

namespace MultiSelectPackage.Components
{
	public partial class MultiSelect<T> : ComponentBase
	{
		#region Parameters

		[Parameter]
		public required IEnumerable<T> Items { get; set; }

		[Parameter]
		public required string IdentifierProperty { get; set; }

		[Parameter]
		public required string DisplayProperty { get; set; }

		[Parameter]
		public EventCallback<List<T>> ValuesChanged { get; set; }

		[Parameter]
		public bool CanSearch { get; set; } = true;

		[Parameter]
		public string SearchPlaceHolder { get; set; } = "Search...";

		[Parameter]
		public string Height { get; set; } = string.Empty;

		[Parameter]
		public string Width { get; set; } = "200px";

		[Parameter]
		public string CustomStyle { get; set; } = string.Empty;

		#endregion

		#region Properties

		private List<T> ItemList = new List<T>();
		private List<T> FilteredItemList = new List<T>();
		private List<object> SelectedValues = new List<object>();
		private bool isDropdownOpen = false;

		#endregion

		#region Methods

		protected override async Task OnParametersSetAsync()
		{
			if (Items != null && Items.Any())
			{
				if (!ItemList.Any() || !ItemsAreEqual(ItemList, Items))
				{
					ItemList = Items.ToList();
					FilteredItemList = ItemList;  // Initialize the filtered list with all items
				}
			}

			await base.OnParametersSetAsync();
		}

		private bool ItemsAreEqual(IEnumerable<T> list1, IEnumerable<T> list2)
		{
			var identifierProperty = typeof(T).GetProperty(IdentifierProperty);
			if (identifierProperty == null)
			{
				throw new InvalidOperationException($"Property '{IdentifierProperty}' not found on type '{typeof(T).Name}'");
			}

			var list1Identifiers = list1.Select(item => identifierProperty.GetValue(item)).ToList();
			var list2Identifiers = list2.Select(item => identifierProperty.GetValue(item)).ToList();

			return list1Identifiers.SequenceEqual(list2Identifiers);
		}

		private object GetPropertyValue(T item, string propertyName)
		{
			var propertyInfo = typeof(T).GetProperty(propertyName);
			if (propertyInfo == null)
			{
				throw new InvalidOperationException($"Property '{propertyName}' not found on type '{typeof(T).Name}'");
			}
			return propertyInfo.GetValue(item);
		}

		// This method filters the list based on the current searchText immediately
		private async Task FilterItems(ChangeEventArgs e)
		{
			var filterText = e.Value?.ToString() ?? string.Empty;
			if (string.IsNullOrWhiteSpace(filterText))
			{
				FilteredItemList = ItemList; // Show all items when search text is empty
			}
			else
			{
				// Filter items based on DisplayProperty (search text matching any part of the display property)
				FilteredItemList = ItemList.Where(item =>
				GetPropertyValue(item, DisplayProperty)
					.ToString()
					.Contains(filterText, StringComparison.CurrentCultureIgnoreCase))
					.ToList();
			}

			await InvokeAsync(StateHasChanged);
		}

		// Check if the item is selected based on the current selection
		private bool IsSelected(T item)
		{
			bool isSelected = false;
			var identifierValue = GetPropertyValue(item, IdentifierProperty);

			if (SelectedValues != null && SelectedValues.Any())
			{
				isSelected = SelectedValues.Any(selectedItem =>
				{
					var selectedIdentifierValue = GetPropertyValue((T)selectedItem, IdentifierProperty);
					return selectedIdentifierValue.Equals(identifierValue);
				});
			}

			return isSelected;
		}

		// This method will handle changes in selection
		private async Task OnValueChanged(T item)
		{
			try
			{
				if (IsSelected(item))
				{
					// If the item is already selected, remove it
					SelectedValues.Remove(item);
				}
				else
				{
					// If the item is not selected, add it
					SelectedValues.Add(item);
				}

				// Trigger the ValuesChanged callback
				if (ValuesChanged.HasDelegate)
				{
					await ValuesChanged.InvokeAsync(SelectedValues.Cast<T>().ToList());
				}

				// Re-render the component
				await InvokeAsync(StateHasChanged);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		// Toggle the dropdown visibility
		private void ToggleDropdown()
		{
			isDropdownOpen = !isDropdownOpen;
			StateHasChanged(); // Force re-render
		}

		private string GetHeight()
		{
			if (string.IsNullOrWhiteSpace(Height))
			{
				return string.Empty;
			}
			else
			{
				return $"height: {(string.IsNullOrWhiteSpace(Height) ? string.Empty : Height)};";
			}
		}

		private string GetWidth()
		{
			return $"width: {Width};";
		}

		private string GetCustomStyle()
		{
			if (string.IsNullOrWhiteSpace(CustomStyle))
			{
				return string.Empty;
			}
			else
			{
				return $"{(string.IsNullOrWhiteSpace(CustomStyle) ? string.Empty : CustomStyle)};";
			}
		}

		#endregion
	}
}
