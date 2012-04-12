// ------------------------------------------------------------------------------
// <copyright file="StockListView.xaml.cs" company="bbv Software Services AG">
//   Copyright (c) 2012
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace SimpleStock.StockOverview.StockList
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;

    using SimpleStock.StockService;

    /// <summary>
    /// Interaction logic for StockListView.xaml
    /// </summary>
    public partial class StockListView : UserControl
    {
        public StockListView()
        {
            this.InitializeComponent();
            this.DataContext = new StockListViewModel(new StockService());
        }

        public static object SampleData
        {
            get
            {
                var item1 = new StockListItemModel { Name = "Item 1" };
                var item2 = new StockListItemModel { Name = "Item 2" };
                var item3 = new StockListItemModel { Name = "Item 3" };
                var col = new ObservableCollection<StockListItemModel> { item1, item2, item3 };

                return new StockListViewModel(new StockService()) { SearchText = "UB*", StockList = col, CurrentStockItem = item2 };
            }
        }
    }
}
