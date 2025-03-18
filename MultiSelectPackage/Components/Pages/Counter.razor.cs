using Microsoft.AspNetCore.Components;

namespace MultiSelectPackage.Components.Pages
{
	public partial class Counter : ComponentBase
	{
		private int currentCount = 0;
		private List<DummyDataDto> selectedItems = new List<DummyDataDto>();

		private void IncrementCount()
		{
			currentCount++;
		}

		public List<DummyDataDto> DummyData = new List<DummyDataDto>();

		protected override void OnInitialized()
		{
			DummyData.Add(new DummyDataDto { Id = 1, Name = "John", Surname = "Doe" });
			DummyData.Add(new DummyDataDto { Id = 2, Name = "Jane", Surname = "Doe" });
			DummyData.Add(new DummyDataDto { Id = 3, Name = "Antonio", Surname = "Glešić" });
			DummyData.Add(new DummyDataDto { Id = 4, Name = "Diana", Surname = "Krndija" });

			selectedItems = new List<DummyDataDto>();

			base.OnInitialized();
		}

		public void OnSelectedItemsChanged(List<DummyDataDto> items)
		{
			try
			{
				selectedItems = items;
				Console.WriteLine("Selected items:");
				foreach (var item in items)
				{
					Console.WriteLine(item.FullName);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
