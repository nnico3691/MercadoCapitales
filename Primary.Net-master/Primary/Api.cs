using Newtonsoft.Json;
using Primary.Data;
using Primary.Data.Orders;
using Primary.WebSockets;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Primary
{
    public class Api
    {
        /// <summary>This is the default production endpoint.</summary>
        public static Uri ProductionEndpoint => new Uri("https://api.primary.com.ar");

        /// <summary>This is the default demo endpoint.</summary>
        /// <remarks>You can get a demo username at https://remarkets.primary.ventures.</remarks>
        public static Uri DemoEndpoint => new Uri("https://api.remarkets.primary.com.ar");

        /// <summary>
        /// Build a new API object.
        /// </summary>
        public Api(Uri baseUri, HttpClient httpClient = null)
        {
            BaseUri = baseUri;
            HttpClient = httpClient ?? new HttpClient();
        }

        public Uri BaseUri { get; private set; }
        public HttpClient HttpClient { get; private set; }

        #region Login

        public string AccessToken { get; private set; }

        /// <summary>
        /// Initialize the specified environment.
        /// </summary>
        /// <param name="username">User used for authentication.</param>
        /// <param name="password">Password used for authentication.</param>
        /// <returns></returns>
        public async Task<bool> Login(string username, string password)
        {
            var uri = new Uri(BaseUri, "/auth/getToken");

            HttpClient.DefaultRequestHeaders.Clear();
            HttpClient.DefaultRequestHeaders.Add("X-Username", username);
            HttpClient.DefaultRequestHeaders.Add("X-Password", password);

            var result = await HttpClient.PostAsync(uri, new StringContent(string.Empty));

            if (result.IsSuccessStatusCode)
            {
                AccessToken = result.Headers.GetValues("X-Auth-Token").FirstOrDefault();
                HttpClient.DefaultRequestHeaders.Clear();
                HttpClient.DefaultRequestHeaders.Add("X-Auth-Token", AccessToken);
            }

            return result.IsSuccessStatusCode;
        }

        public const string DemoUsername = "messanicolas520689";
        public const string DemoPassword = "lwwumN3$";
        public const string DemoAccount = "REM20689";

        #endregion

        #region Instruments information

        /// <summary>
        /// Get all instruments currently traded on the exchange.
        /// </summary>
        /// <returns>Instruments information.</returns>
        public async Task<IEnumerable<Instrument>> GetAllInstruments()
        {
            var uri = new Uri(BaseUri, "/rest/instruments/details");
            var response = await HttpClient.GetStringAsync(uri);

            var data = JsonConvert.DeserializeObject<GetAllInstrumentsResponse>(response);
            return data.Instruments;
        }

        private class GetAllInstrumentsResponse
        {
            [JsonProperty("instruments")]
            public List<Instrument> Instruments { get; set; }
        }

        #endregion

        #region Position data
        /// <summary>
        /// Obtiene las posiciones para una cuenta específica.
        /// </summary>
        /// <param name="accountName">Nombre de la cuenta para la cual se desean obtener las posiciones.</param>
        /// <returns>Lista de posiciones de la cuenta.</returns>
        public async Task<List<Data.PrimaryRiskAPI.Position>> GetPositions(string accountName)
        {
            var uri = new Uri(DemoEndpoint, $"/rest/risk/position/getPositions/{accountName}");
            var response = await HttpClient.GetStringAsync(uri);
            var data = JsonConvert.DeserializeObject<GetPositionsResponse>(response);

            if (data.Status != "OK")
            {
                throw new Exception($"Error al obtener posiciones: {data.Status}");
            }

            return data.Positions;
        }

        public class GetPositionsResponse
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("positions")]
            public List<Data.PrimaryRiskAPI.Position> Positions { get; set; }

        }

        public async Task<AccountReportResponse> GetAccountReport(string accountName)
        {
            var uri = new Uri(DemoEndpoint, $"/rest/risk/accountReport/{accountName}");
            var response = await HttpClient.GetStringAsync(uri);

            // Deserialize the response into AccountReportResponse
            var data = JsonConvert.DeserializeObject<AccountReportResponse>(response);

            // Check if the status is OK
            if (data.Status != "OK")
            {
                throw new Exception($"Error al obtener el informe de la cuenta: {data.Status}");
            }

            // Return the AccountReportResponse object
            return data;
        }


        public class AccountReportResponse
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("accountData")]
            public AccountData AccountData { get; set; }

            [JsonProperty("hasError")]
            public bool HasError { get; set; }

            [JsonProperty("errorDetail")]
            public string ErrorDetail { get; set; }

            [JsonProperty("lastCalculation")]
            public long LastCalculation { get; set; }

            [JsonProperty("portfolio")]
            public decimal Portfolio { get; set; }

            [JsonProperty("ordersMargin")]
            public decimal OrdersMargin { get; set; }

            [JsonProperty("currentCash")]
            public decimal CurrentCash { get; set; }

            [JsonProperty("dailyDiff")]
            public decimal DailyDiff { get; set; }

            [JsonProperty("uncoveredMargin")]
            public decimal UncoveredMargin { get; set; }
        }

        public class AccountData
        {
            [JsonProperty("accountName")]
            public string AccountName { get; set; }

            [JsonProperty("marketMember")]
            public string MarketMember { get; set; }

            [JsonProperty("marketMemberIdentity")]
            public string MarketMemberIdentity { get; set; }

            [JsonProperty("collateral")]
            public decimal Collateral { get; set; }

            [JsonProperty("margin")]
            public decimal Margin { get; set; }

            [JsonProperty("availableToCollateral")]
            public decimal AvailableToCollateral { get; set; }

            [JsonProperty("detailedAccountReports")]
            public Dictionary<string, DetailedAccountReport> DetailedAccountReports { get; set; }
        }

        public class DetailedAccountReport
        {
            [JsonProperty("currencyBalance")]
            public CurrencyBalance CurrencyBalance { get; set; }

            [JsonProperty("availableToOperate")]
            public AvailableToOperate AvailableToOperate { get; set; }

            [JsonProperty("settlementDate")]
            public long SettlementDate { get; set; }
        }

        public class CurrencyBalance
        {
            [JsonProperty("detailedCurrencyBalance")]
            public Dictionary<string, CurrencyDetail> DetailedCurrencyBalance { get; set; }
        }

        public class CurrencyDetail
        {
            [JsonProperty("consumed")]
            public decimal Consumed { get; set; }

            [JsonProperty("available")]
            public decimal Available { get; set; }
        }

        public class AvailableToOperate
        {
            [JsonProperty("cash")]
            public Cash Cash { get; set; }

            [JsonProperty("movements")]
            public int Movements { get; set; }

            [JsonProperty("credit")]
            public object Credit { get; set; } // Assuming credit can be null

            [JsonProperty("total")]
            public decimal Total { get; set; }

            [JsonProperty("pendingMovements")]
            public int PendingMovements { get; set; }
        }

        public class Cash
        {
            [JsonProperty("totalCash")]
            public decimal TotalCash { get; set; }

            [JsonProperty("detailedCash")]
            public Dictionary<string, decimal> DetailedCash { get; set; }
        }

        public async Task<DetailedPositionResponse> GetDetailedPosition(string accountName)
        {
            var uri = new Uri(DemoEndpoint, $"/rest/risk/detailedPosition/{accountName}");
            var response = await HttpClient.GetStringAsync(uri);

            // Deserialize the response into AccountReportResponse
            var data = JsonConvert.DeserializeObject<DetailedPositionResponse>(response);

            // Check if the status is OK
            if (data.Status != "OK")
            {
                throw new Exception($"Error al obtener el informe de la cuenta: {data.Status}");
            }

            // Return the AccountReportResponse object
            return data;
        }

        public class DetailedPositionResponse
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("detailedPosition")]
            public DetailedPosition DetailedPosition { get; set; }

            [JsonProperty("lastCalculation")]
            public long LastCalculation { get; set; }
        }

        public class DetailedPosition
        {
            [JsonProperty("account")]
            public string Account { get; set; }

            [JsonProperty("totalDailyDiffPlain")]
            public decimal TotalDailyDiffPlain { get; set; }

            [JsonProperty("totalMarketValue")]
            public decimal TotalMarketValue { get; set; }

            [JsonProperty("report")]
            public Dictionary<string, Dictionary<string, ContractDetail>> Report { get; set; }
        }


        public class ContractDetail
        {
            [JsonProperty("detailedPositions")]
            public List<DetailedPositionInfo> DetailedPositions { get; set; }

            [JsonProperty("instrumentInitialSize")]
            public decimal InstrumentInitialSize { get; set; }

            [JsonProperty("instrumentFilledSize")]
            public decimal InstrumentFilledSize { get; set; }

            [JsonProperty("instrumentCurrentSize")]
            public decimal InstrumentCurrentSize { get; set; }
        }

        public class DetailedPositionInfo
        {
            [JsonProperty("symbolReference")]
            public string SymbolReference { get; set; }

            [JsonProperty("contractType")]
            public string ContractType { get; set; }

            [JsonProperty("priceConversionFactor")]
            public decimal PriceConversionFactor { get; set; }

            [JsonProperty("contractSize")]
            public decimal ContractSize { get; set; }

            [JsonProperty("marketPrice")]
            public decimal MarketPrice { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("exchangeRate")]
            public decimal ExchangeRate { get; set; }

            [JsonProperty("contractMultiplier")]
            public decimal ContractMultiplier { get; set; }

            [JsonProperty("totalInitialSize")]
            public decimal TotalInitialSize { get; set; }

            [JsonProperty("buyInitialSize")]
            public decimal BuyInitialSize { get; set; }

            [JsonProperty("sellInitialSize")]
            public decimal SellInitialSize { get; set; }

            [JsonProperty("buyInitialPrice")]
            public decimal BuyInitialPrice { get; set; }

            [JsonProperty("sellInitialPrice")]
            public decimal SellInitialPrice { get; set; }

            [JsonProperty("totalFilledSize")]
            public decimal TotalFilledSize { get; set; }

            [JsonProperty("buyFilledSize")]
            public decimal BuyFilledSize { get; set; }

            [JsonProperty("sellFilledSize")]
            public decimal SellFilledSize { get; set; }

            [JsonProperty("buyFilledPrice")]
            public decimal BuyFilledPrice { get; set; }

            [JsonProperty("sellFilledPrice")]
            public decimal SellFilledPrice { get; set; }

            [JsonProperty("totalCurrentSize")]
            public decimal TotalCurrentSize { get; set; }

            [JsonProperty("buyCurrentSize")]
            public decimal BuyCurrentSize { get; set; }

            [JsonProperty("sellCurrentSize")]
            public decimal SellCurrentSize { get; set; }

            [JsonProperty("detailedDailyDiff")]
            public DetailedDailyDiff DetailedDailyDiff { get; set; }
        }

        public class DetailedDailyDiff
        {
            [JsonProperty("buyPricePPPDiff")]
            public decimal BuyPricePPPDiff { get; set; }

            [JsonProperty("sellPricePPPDiff")]
            public decimal SellPricePPPDiff { get; set; }

            [JsonProperty("totalDailyDiff")]
            public decimal TotalDailyDiff { get; set; }

            [JsonProperty("buyDailyDiff")]
            public decimal BuyDailyDiff { get; set; }

            [JsonProperty("sellDailyDiff")]
            public decimal SellDailyDiff { get; set; }

            [JsonProperty("totalDailyDiffPlain")]
            public decimal TotalDailyDiffPlain { get; set; }

            [JsonProperty("buyDailyDiffPlain")]
            public decimal BuyDailyDiffPlain { get; set; }

            [JsonProperty("sellDailyDiffPlain")]
            public decimal SellDailyDiffPlain { get; set; }
        }
        #endregion

        #region Historical data

        /// <summary>
        /// Get historical trades for a specific instrument.
        /// </summary>
        /// <param name="instrumentId">Instrument to get information for.</param>
        /// <param name="dateFrom">First date of trading information.</param>
        /// <param name="dateTo">Last date of trading information.</param>
        /// <returns>Trade information for the instrument in the specified period.</returns>
        public async Task<IEnumerable<Trade>> GetHistoricalTrades(InstrumentId instrumentId,
                                                                    DateTime dateFrom,
                                                                    DateTime dateTo)
        {
            UriBuilder builder = new UriBuilder(BaseUri + "/rest/data/getTrades");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["marketId"] = instrumentId.Market;
            query["symbol"] = instrumentId.Symbol;
            query["dateFrom"] = dateFrom.ToString("yyyy-MM-dd");
            query["dateTo"] = dateTo.ToString("yyyy-MM-dd");
            builder.Query = query.ToString();

            var response = await HttpClient.GetStringAsync(builder.Uri);
            var data = JsonConvert.DeserializeObject<GetTradesResponse>(response);

            if (data.Status == Status.Error)
            {
                throw new Exception($"{data.Message} ({data.Description})");
            }

            return data.Trades;
        }

        private class GetTradesResponse
        {
            [JsonProperty("status")]
            public string Status;

            [JsonProperty("message")]
            public string Message;

            [JsonProperty("description")]
            public string Description;

            [JsonProperty("trades")]
            public List<Trade> Trades { get; set; }
        }

        #endregion

        #region Market data sockets

        /// <summary>
        /// Create a Market Data web socket to receive real-time market data.
        /// </summary>
        /// <param name="instruments">Instruments to watch.</param>
        /// <param name="entries">Market data entries to watch.</param>
        /// <param name="level"></param>
        /// <param name="depth">Depth of the book.</param>
        /// <returns>The market data web socket.</returns>
        public MarketDataWebSocket CreateMarketDataSocket(IEnumerable<InstrumentId> instruments,
                                                          IEnumerable<Entry> entries,
                                                          uint level, uint depth
        )
        {
            return CreateMarketDataSocket(instruments, entries, level, depth, new CancellationToken());
        }

        /// <summary>
        /// Create a Market Data web socket to receive real-time market data.
        /// </summary>
        /// <param name="instrumentIds">Instruments to watch.</param>
        /// <param name="entries">Market data entries to watch.</param>
        /// <param name="level">Real-time message update time.
        ///     <list type="table">
        ///         <listheader> <term>Level</term> <description>Update time (ms)</description> </listheader>
        ///         <item> <term>1</term> <description>100</description> </item>
        ///         <item> <term>2</term> <description>500</description> </item>
        ///         <item> <term>3</term> <description>1000</description> </item>
        ///         <item> <term>4</term> <description>3000</description> </item>
        ///         <item> <term>5</term> <description>6000</description> </item>
        ///     </list>
        /// </param>
        /// <param name="depth">Depth of the book.</param>
        /// <param name="cancellationToken">Custom cancellation token to end the socket task.</param>
        /// <returns>The market data web socket.</returns>
        public MarketDataWebSocket CreateMarketDataSocket(IEnumerable<InstrumentId> instrumentIds,
                                                          IEnumerable<Entry> entries,
                                                          uint level, uint depth,
                                                          CancellationToken cancellationToken
        )
        {

            var marketDataToRequest = new MarketDataInfo()
            {
                Depth = depth,
                Entries = entries.ToArray(),
                Level = level,
                Products = instrumentIds.ToArray()
            };

            return new MarketDataWebSocket(this, marketDataToRequest, cancellationToken);
        }

        #endregion

        #region Order data sockets

        /// <summary>
        /// Create a Order Data web socket to receive real-time orders data.
        /// </summary>
        /// <param name="accounts">Accounts to get order events from.</param>
        /// <returns>The order data web socket.</returns>
        public OrderDataWebSocket CreateOrderDataSocket(IEnumerable<string> accounts)
        {
            return CreateOrderDataSocket(accounts, new CancellationToken());
        }

        /// <summary>
        /// Create a Market Data web socket to receive real-time market data.
        /// </summary>
        /// <param name="accounts">Accounts to get order events from.</param>
        /// <param name="cancellationToken">Custom cancellation token to end the socket task.</param>
        /// <returns>The order data web socket.</returns>
        public OrderDataWebSocket CreateOrderDataSocket(IEnumerable<string> accounts,
                                                        CancellationToken cancellationToken
        )
        {
            var request = new OrderDataRequest
            {
                Accounts = accounts.Select(a => new OrderStatus.AccountId() { Id = a }).ToArray()
            };

            return new OrderDataWebSocket(this, request, cancellationToken);
        }

        #endregion

        #region Orders

        /// <summary>
        /// Send an order to the specific account.
        /// </summary>
        /// <param name="account">Account to send the order to.</param>
        /// <param name="order">Order to send.</param>
        /// <returns>Order identifier.</returns>
        public async Task<OrderId> SubmitOrder(string account, Order order)
        {
            var builder = new UriBuilder(BaseUri + "/rest/order/newSingleOrder");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["marketId"] = "ROFX";
            query["symbol"] = order.InstrumentId.Symbol;
            query["price"] = order.Price?.ToString(CultureInfo.InvariantCulture);
            query["orderQty"] = order.Quantity.ToString();
            query["ordType"] = order.Type.ToApiString();
            query["side"] = order.Side.ToApiString();
            query["timeInForce"] = order.Expiration.ToApiString();
            query["account"] = account;
            query["cancelPrevious"] = order.CancelPrevious.ToString(CultureInfo.InvariantCulture);
            query["iceberg"] = order.Iceberg.ToString(CultureInfo.InvariantCulture);
            query["expireDate"] = order.ExpirationDate.ToString("yyyyMMdd");

            if (order.Iceberg)
            {
                query["displayQty"] = order.DisplayQuantity.ToString(CultureInfo.InvariantCulture);
            }
            builder.Query = query.ToString();

            var jsonResponse = await HttpClient.GetStringAsync(builder.Uri);

            var response = JsonConvert.DeserializeObject<OrderIdResponse>(jsonResponse);
            if (response.Status == Status.Error)
            {
                throw new Exception($"{response.Message} ({response.Description})");
            }

            return new OrderId()
            {
                ClientOrderId = response.Order.ClientId,
                Proprietary = response.Order.Proprietary
            };
        }

        /// <summary>
        /// Get order information from identifier.
        /// </summary>
        /// <param name="orderId">Order identifier.</param>
        /// <returns>Order information.</returns>
        public async Task<GetOrderResponse> GetOrderStatus(OrderId orderId)
        {

            var builder = new UriBuilder(BaseUri + "/rest/order/id");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["clOrdId"] = orderId.ClientOrderId;
            query["proprietary"] = orderId.Proprietary;
            builder.Query = query.ToString();

            var jsonResponse = await HttpClient.GetStringAsync(builder.Uri);

            var response = JsonConvert.DeserializeObject<GetOrderResponse>(jsonResponse);
            if (response.Status == Status.Error)
            {
                throw new Exception($"{response.Message} ({response.Description})");
            }

            return response;
        }

        /// <summary>
        /// Cancel an order.
        /// </summary>
        /// <param name="orderId">Order identifier to cancel.</param>
        public async Task CancelOrder(OrderId orderId)
        {

            var builder = new UriBuilder(BaseUri + "/rest/order/cancelById");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["clOrdId"] = orderId.ClientOrderId;
            query["proprietary"] = orderId.Proprietary;
            builder.Query = query.ToString();

            var jsonResponse = await HttpClient.GetStringAsync(builder.Uri);

            var response = JsonConvert.DeserializeObject<OrderIdResponse>(jsonResponse);
            //if (response.Status == Status.Error)
            //{
            //    throw new Exception($"{response.Message} ({response.Description})");
            //}
        }

        /// <summary>
        /// Consultar Ordenes Operadas
        /// Consulta que devuelve todas las ordenes que están total o parcialmente operadas.
        /// </summary>
        /// <param name="accountId">Account identifier.</param>
        /// <returns>Orders information.</returns>
        public async Task<GetOrdersResponse> GetOrderFilleds(Account account)
        {

            var builder = new UriBuilder(BaseUri + "/rest/order/filleds");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["accountId"] = account.accountId;
          
            builder.Query = query.ToString();

            var jsonResponse = await HttpClient.GetStringAsync(builder.Uri);

            var response = JsonConvert.DeserializeObject<GetOrdersResponse>(jsonResponse);
            if (response.Status == Status.Error)
            {
                throw new Exception($"{response.Message} ({response.Description})");
            }

            return response;
        }

        /// <summary>
        /// Estado de orden por ID Cuenta
        /// Consulta que devuelve el último estado de los request (client order ID) asociadas a una
        /// cuenta.Es decir, de los si se hizo un request para dar de alta una orden, y luego se hizo otro
        /// para darlo de baja entonces esta API devolverá 2 ordenes, una con el ultimo estado asociado
        /// al request de alta y otra con el ultimo estado asociado al request de baja.
        /// </summary>
        /// <param name="accountId">Account identifier.</param>
        /// <returns>Orders information.</returns>
        public async Task<GetOrdersResponse> GetOrderAll(Account account)
        {

            var builder = new UriBuilder(BaseUri + "/rest/order/all");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["accountId"] = account.accountId;

            builder.Query = query.ToString();

            var jsonResponse = await HttpClient.GetStringAsync(builder.Uri);

            var response = JsonConvert.DeserializeObject<GetOrdersResponse>(jsonResponse);
            if (response.Status == Status.Error)
            {
                throw new Exception($"{response.Message} ({response.Description})");
            }

            return response;
        }

        private struct OrderIdResponse
        {
            [JsonProperty("status")]
            public string Status;

            [JsonProperty("message")]
            public string Message;

            [JsonProperty("description")]
            public string Description;

            public struct Id
            {
                [JsonProperty("clientId")]
                public string ClientId { get; set; }

                [JsonProperty("proprietary")]
                public string Proprietary { get; set; }
            }

            [JsonProperty("order")]
            public Id Order;
        }

        public struct GetOrderResponse
        {
            [JsonProperty("status")]
            public string Status;

            [JsonProperty("message")]
            public string Message;

            [JsonProperty("description")]
            public string Description;

            [JsonProperty("order")]
            public OrderStatus Order;
        }

        public struct GetOrdersResponse
        {
            [JsonProperty("status")]
            public string Status;

            [JsonProperty("message")]
            public string Message;

            [JsonProperty("description")]
            public string Description;

            [JsonProperty("orders")]
            public List<OrderStatus> Orders;
        }

        #endregion

        #region Constants

        private static class Status
        {
            public const string Error = "ERROR";
        }

        #endregion

    }
}

