using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace NotissimusApp.Services
{
    internal class XmlService
    {
        public List<Offer> ParseXmlData(string xmlDataString)
        {
            List<Offer> offersList = new List<Offer>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlDataString);

            XmlNodeList offerNodes = xmlDoc.SelectNodes("/yml_catalog/shop/offers/offer");

            foreach (XmlNode offerNode in offerNodes)
            {
                Offer offer = new Offer
                {
                    Id = offerNode.Attributes["id"]?.Value,
                    Type = offerNode.Attributes["type"]?.Value,
                    Bid = offerNode.Attributes["bid"]?.Value,
                    Cbid = offerNode.Attributes["cbid"]?.Value,
                    Available = offerNode.Attributes["available"]?.Value,
                    Url = offerNode.SelectSingleNode("url")?.InnerText,
                    Price = offerNode.SelectSingleNode("price")?.InnerText,
                    CurrencyId = offerNode.SelectSingleNode("currencyId")?.InnerText,
                    CategoryId = offerNode.SelectSingleNode("categoryId")?.InnerText,
                    Picture = offerNode.SelectSingleNode("picture")?.InnerText,
                    Delivery = offerNode.SelectSingleNode("delivery")?.InnerText,
                    LocalDeliveryCost = offerNode.SelectSingleNode("local_delivery_cost")?.InnerText,
                    TypePrefix = offerNode.SelectSingleNode("typePrefix")?.InnerText,
                    Vendor = offerNode.SelectSingleNode("vendor")?.InnerText,
                    VendorCode = offerNode.SelectSingleNode("vendorCode")?.InnerText,
                    Model = offerNode.SelectSingleNode("model")?.InnerText,
                    Description = offerNode.SelectSingleNode("description")?.InnerText,
                    ManufacturerWarranty = offerNode.SelectSingleNode("manufacturer_warranty")?.InnerText,
                    CountryOfOrigin = offerNode.SelectSingleNode("country_of_origin")?.InnerText,
                    Author = offerNode.SelectSingleNode("author")?.InnerText,
                    Name = offerNode.SelectSingleNode("name")?.InnerText,
                    Publisher = offerNode.SelectSingleNode("publisher")?.InnerText,
                    Series = offerNode.SelectSingleNode("series")?.InnerText,
                    Year = offerNode.SelectSingleNode("year")?.InnerText,
                    ISBN = offerNode.SelectSingleNode("ISBN")?.InnerText,
                    Volume = offerNode.SelectSingleNode("volume")?.InnerText,
                    Part = offerNode.SelectSingleNode("part")?.InnerText,
                    Language = offerNode.SelectSingleNode("language")?.InnerText,
                    Binding = offerNode.SelectSingleNode("binding")?.InnerText,
                    PageExtent = offerNode.SelectSingleNode("page_extent")?.InnerText,
                    PerformedBy = offerNode.SelectSingleNode("performed_by")?.InnerText,
                    PerformanceType = offerNode.SelectSingleNode("performance_type")?.InnerText,
                    Storage = offerNode.SelectSingleNode("storage")?.InnerText,
                    Format = offerNode.SelectSingleNode("format")?.InnerText,
                    RecordingLength = offerNode.SelectSingleNode("recording_length")?.InnerText,
                    WorldRegion = offerNode.SelectSingleNode("worldRegion")?.InnerText,
                    Country = offerNode.SelectSingleNode("country")?.InnerText,
                    Region = offerNode.SelectSingleNode("region")?.InnerText,
                    Days = offerNode.SelectSingleNode("days")?.InnerText,
                    DataTour = offerNode.Attributes["dataTour"]?.Value,
                    HotelStars = offerNode.SelectSingleNode("hotel_stars")?.InnerText,
                    Room = offerNode.SelectSingleNode("room")?.InnerText,
                    Meal = offerNode.SelectSingleNode("meal")?.InnerText,
                    Included = offerNode.SelectSingleNode("included")?.InnerText,
                    Transport = offerNode.SelectSingleNode("transport")?.InnerText,
                    Place = offerNode.SelectSingleNode("place")?.InnerText,
                    HallPlan = offerNode.SelectSingleNode("hall/@plan")?.Value,
                    HallPart = offerNode.SelectSingleNode("hall_part")?.InnerText,
                    Date = offerNode.Attributes["date"]?.Value,
                    IsPremiere = offerNode.SelectSingleNode("is_premiere")?.InnerText,
                    IsKids = offerNode.SelectSingleNode("is_kids")?.InnerText,
                };

                offersList.Add(offer);
            }

            return offersList;
        }
    }
}