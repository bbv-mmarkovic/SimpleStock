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

    using SimpleStock.StockService;

    public class StockListViewModel : INotifyPropertyChanged
    {
        private StockListItemModel currentStockItem;

        public StockListViewModel()
        {
        }

        public StockListViewModel(IStockService stockService)
        {
            IList<StockEntry> stockEntries = stockService.GetStockList();
            IEnumerable<StockListItemModel> stockListItemModels = ConvertToItemModels(stockEntries);

            this.StockList = new ObservableCollection<StockListItemModel>(stockListItemModels);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<StockListItemModel> StockList { get; set; }

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
    }
}