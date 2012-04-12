// ------------------------------------------------------------------------------
// <copyright file="StockOverviewViewModel.cs" company="bbv Software Services AG">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;

    using SimpleStock.StockService;

    public delegate void ApplyFilter(IEnumerable<StockEntry> stockList);

    public class SearchStockCommand : ICommand
    {

        private readonly IStockService stockService;
        private readonly Func<bool> canExecute;
        private readonly ApplyFilter applyFilter;

        public SearchStockCommand(IStockService stockService, Func<bool> canExecute, ApplyFilter applyFilter)
        {
            this.stockService = stockService;
            this.canExecute = canExecute;
            this.applyFilter = applyFilter;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var filterValue = parameter as string;

            if (!this.canExecute() || string.IsNullOrEmpty(filterValue))
            {
                return;
            }

            string lowerFilterValue = filterValue.ToLower();

            IList<StockEntry> stockList = this.stockService.GetStockList();
            IList<StockEntry> filteredStockList = lowerFilterValue != "*" 
                ? stockList.Where(stockEntry => stockEntry.Name.ToLower().Contains(lowerFilterValue)).ToList()
                : stockList;

            if (this.applyFilter != null)
            {
                this.applyFilter(filteredStockList);
            }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute();
        }

        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}