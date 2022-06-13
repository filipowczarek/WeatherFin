using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherFin.Data.WeatherData;

namespace WeatherFin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet =true)]
        public string SearchCity { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime SearchDate { get; set; }
        public WeatherDataReader WeatherDataReader = new WeatherDataReader();
        public IEnumerable<WeatherModel> weathers { get; set; }
        public IEnumerable<WeatherModel> searchedList { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (User.IsInRole("Admin"))
            {
                refreshData();
            }
            var WeatherDataReader = new WeatherDataReader();
            if(SearchCity !=null)
            weathers = WeatherDataReader.readDataToList();
            if (SearchCity != null)
            {
                searchedList = WeatherDataReader.searchData(weathers, SearchCity, SearchDate);
            }
            else
            {
                searchedList = weathers;
            }

        }

        public void refreshData()
        {
            var WeatherDataReader = new WeatherDataReader();
            WeatherDataReader.readDataToDB();
        }
    }
}