// ------------------------------------------------------------------------------
// <copyright file="StockDetailViewModel.cs" company="bbv Software Services AG">
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

namespace SimpleStock.StockOverview.StockDetail
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Media.Imaging;

    using SimpleStock.StockService;

    public class StockDetailViewModel : INotifyPropertyChanged
    {
        private StockDetailModel stockDetail;

        public event PropertyChangedEventHandler PropertyChanged;

        public StockDetailModel StockDetail
        {
            get
            {
                return this.stockDetail;
            }

            set
            {
                this.stockDetail = value;

                this.RaisePropertyChanged("StockDetail");
                this.RaisePropertyChanged("PositiveChange");
                this.RaisePropertyChanged("NegativeChange");
                this.RaisePropertyChanged("ChartImage");
            }
        }

        public bool PositiveChange
        {
            get { return this.stockDetail != null && this.stockDetail.DailyChange > 0; }
        }

        public bool NegativeChange
        {
            get { return this.stockDetail != null && this.stockDetail.DailyChange < 0; }
        }

        public BitmapImage ChartImage
        {
            get { return this.stockDetail != null ? ConvertToBitmapImage(this.stockDetail.Chart) : new BitmapImage(); }
        }

        public void SetStockDetail(StockDetailInfo stockDetailInfo)
        {
            this.StockDetail = ConvertToDetailModel(stockDetailInfo);
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private static StockDetailModel ConvertToDetailModel(StockDetailInfo stockDetailInfo)
        {
            return new StockDetailModel
            {
                Chart = stockDetailInfo.Chart,
                DailyChange = stockDetailInfo.DailyChange,
                DailyHigh = stockDetailInfo.DailyHigh,
                DailyLow = stockDetailInfo.DailyLow,
                DailyVolume = stockDetailInfo.DailyVolume,
                Id = stockDetailInfo.Id,
                LastTrade = stockDetailInfo.LastTrade,
                Name = stockDetailInfo.Name,
                NextGeneralMeeting = stockDetailInfo.NextGeneralMeeting,
                ValorSymbol = stockDetailInfo.ValorSymbol,
                WebSite = stockDetailInfo.WebSite
            };
        }

        private static BitmapImage ConvertToBitmapImage(Image img)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CreateOptions = BitmapCreateOptions.None;
            bitmapImage.CacheOption = BitmapCacheOption.Default;
            bitmapImage.StreamSource = ImageToStream(img);
            bitmapImage.EndInit();

            return bitmapImage;
        }

        private static MemoryStream ImageToStream(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Png);
            ms.Flush();

            return ms;
        }
    }
}