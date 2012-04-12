// ------------------------------------------------------------------------------
// <copyright file="StockListViewModel.cs" company="bbv Software Services AG">
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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Input;

    using SimpleStock.StockService;

    public class StockListViewModel : INotifyPropertyChanged
    {
        private readonly SearchStockCommand searchStockCommand;

        private StockListItemModel currentStockItem;

        private ObservableCollection<StockListItemModel> stockList;

        private string searchText;

        public StockListViewModel()
            : this(new StockService())
        {
        }

        public StockListViewModel(IStockService stockService)
        {
            IList<StockEntry> stockEntries = stockService.GetStockList();
            IEnumerable<StockListItemModel> stockListItemModels = ConvertToItemModels(stockEntries);

            this.searchText = "*";
            this.StockList = new ObservableCollection<StockListItemModel>(stockListItemModels);
            this.searchStockCommand = new SearchStockCommand(stockService, () => this.CanSearch, this.FilterStocklist);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string SearchText
        {
            get
            {
                return this.searchText;
            }

            set
            {
                this.searchText = value;

                this.RaisePropertyChanged("SearchText");
                this.searchStockCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<StockListItemModel> StockList
        {
            get
            {
                return this.stockList;
            }

            set
            {
                this.stockList = value;
                this.RaisePropertyChanged("StockList");
            }
        }

        public StockListItemModel CurrentStockItem
        {
            get
            {
                return this.currentStockItem;
            }

            set
            {
                this.currentStockItem = value;
                this.RaisePropertyChanged("CurrentStockItem");
            }
        }

        public bool CanSearch
        {
            get
            {
                return !string.IsNullOrEmpty(this.SearchText);
            }
        }

        public ICommand SearchCommand
        {
            get { return this.searchStockCommand; }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private static IEnumerable<StockListItemModel> ConvertToItemModels(IEnumerable<StockEntry> entries)
        {
            return entries.Select(entry => new StockListItemModel { Id = entry.Id, Name = entry.Name }).ToList();
        }

        private void FilterStocklist(IEnumerable<StockEntry> newStockList)
        {
            IList<StockListItemModel> stockListItems = newStockList
                .Select(itemModel => new StockListItemModel { Id = itemModel.Id, Name = itemModel.Name })
                .ToList();

            this.StockList = new ObservableCollection<StockListItemModel>(stockListItems);
        }
    }
}