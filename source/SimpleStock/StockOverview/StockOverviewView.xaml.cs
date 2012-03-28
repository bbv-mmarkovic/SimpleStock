//-------------------------------------------------------------------------------
// <copyright file="StockOverviewView.xaml.cs" company="bbv Software Services AG">
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

namespace SimpleStock.StockOverview
{
    using System.Windows.Controls;

    using SimpleStock.StockOverview.StockDetail;
    using SimpleStock.StockOverview.StockList;
    using SimpleStock.StockService;

    /// <summary>
    /// Interaction logic for StockOverviewView.xaml
    /// </summary>
    public partial class StockOverviewView : UserControl
    {
        public StockOverviewView()
        {
            InitializeComponent();
            this.DataContext = new StockOverviewViewModel(
                new StockService(),
                (StockListViewModel)this.stockList.DataContext,
                (StockDetailViewModel)this.stockDetail.DataContext);
        }
    }
}
