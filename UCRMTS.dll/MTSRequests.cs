using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UCRMTS.dll.DTOS;
using static System.Net.WebRequestMethods;
using static UCRMTS.dll.MTSRequests;
using static UCRMTS.dll.Scops;
using TypeCode = UCRMTS.dll.DTOS.TypeCode;

namespace UCRMTS.dll
{
    public partial class MTSRequests
    {

        public static async Task<ExchangeDataPiplineDTO> UCRVerification(string ucr, string shipperId)
        {
            Authication authication = new Authication();
            var authResult = await authication.SignIn(AuthicationType.UCRVerifiy);
            string url = $"{ConfigurationManager.AppSettings["MTS_URL"]}/api/v1/consignments/{ucr}";
            using (var http = new HttpClient())
            {

                http.DefaultRequestHeaders.Add("Authorization", $"Bearer {authResult.AccessToken}");
                http.DefaultRequestHeaders.Add("Idempotency-Key", Guid.NewGuid().ToString());
                http.DefaultRequestHeaders.Add("requestId", Guid.NewGuid().ToString());
                http.DefaultRequestHeaders.Add("shipperId", shipperId);
               var response =  await http.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                  return   JsonConvert.DeserializeObject<ExchangeDataPiplineDTO>(result);
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new UCRException(result,response.StatusCode);
                }
             

            }



        }
       
        public  static async Task<ExchangeDataPiplineDTO> ConfirmOrCancelBooking(BookingDetails details , BookingStatus bookingStatus)
        {

     

            var currentObject = new ExchangeDataPiplineDTO()
            {
                ExchangedDocument = new ExchangedDocument()
                {
                    IssueDateTime = DateTime.Now,
                    Issuer = new Issuer()
                    {
                        Id = new List<Id>() { new Id() { Content = details.IssuerTax } }
                    },
                    RoleCode = new List<RoleCode>()
                      {
                          new RoleCode() {Content = details.Type}
                      }

                },
                ExchangedDeclaration = new ExchangedDeclaration()
                {
                    Id = new List<Id>()
                    {
                         new Id(){ Content = details.UCR}
                      },
                    TypeCode = new DTOS.TypeCode()
                    {
                        Content =  ((int)bookingStatus).ToString(),

                    },
                    Declarant = new Declarant()
                    {
                        Id = new List<Id>()
                     {
                         new Id(){ Content =details.ShipperTaxCode},
                     }
                    }


                },
                SpecifiedLogisticsTransportMovement = new List<SpecifiedLogisticsTransportMovement>()
               {
                   new SpecifiedLogisticsTransportMovement()
                   {
                       LoadingEvent = new LoadingEvent()
                       {
                           ScheduledOccurrenceDateTime = details.LoadingTime,
                           OccurrenceLogisticsLocation = new OccurrenceLogisticsLocation()
                           {
                               Id= new List<Id>()
                               {
                                  new Id() { Content = details.PortOfLoadingCode}
                               }
                           },

                       },
                       UnloadingEvent = new UnloadingEvent()
                       {
                             ScheduledOccurrenceDateTime =details.LoadingTime,
                           OccurrenceLogisticsLocation= new OccurrenceLogisticsLocation()
                           {
                               Id= new List<Id>()
                               {
                                   new Id(){Content = details.PortOfDeschargeCode}
                               }
                           }
                       },
                      UsedLogisticsTransportMeans = new UsedLogisticsTransportMeans()
                      {
                          Id = new List<Id>()
                          {
                              new Id(){ Content = details.VesselImo}
                          },
                          Name = new Name()
                          {
                              Content =details.VesselTitle,
                          },
                          RegistrationTradeCountry = new RegistrationTradeCountry()
                          {
                              Id= new List<Id>(){
                                  new Id() {Content = details.TradingCountry}
                              }
                          }

                      },





                   }
               },
                SpecifiedConsignment = new List<SpecifiedConsignment>()
               {
                   new SpecifiedConsignment()
                   {
                       Id= new List<Id>()
                       {
                          new Id(){Content = details.UCR}
                       },
                       Carrier = new Carrier()
                       {
                           Id = new List<Id>()
                           {
                                new Id() {Content = details.ShippingLineID}
                           },
                           Name = new List<Name>()
                           {
                               new Name() {Content = details.ShippingLineCode}
                           }
                       },
                       ConsignmentItemQuantity = new ConsignmentItemQuantity()
                       {
                           Content = details.Details.Sum(a=> a.NoOfPackages).ToString()
                       },
                       GrossWeight =    details.Details.Select(a=> new GrossWeight() {Content = a.GrossWieght.ToString() , UnitCode =a.MeasurmentID}).ToList(),
                       IncludedConsignmentItem = details.Details.Select((line,index) => new IncludedConsignmentItem()
                       {
                           SequenceNumeric = new SequenceNumeric()
                           {
                               Content   =(index+1) .ToString()
                           },
                           NatureIdCargo = new List<NatureIdCargo>()
                           {
                               new NatureIdCargo() {Content=line.CargoDescription}
                           },
                           PhysicalLogisticsShippingMarks = new List<PhysicalLogisticsShippingMark>()
                           {
                               new PhysicalLogisticsShippingMark()
                               {
                                   Marking =new List<Marking>()
                                   {
                                       new Marking()
                                       {
                                           Content = $"{line.Nos} X {line.ContainerType} "
                                       }
                                   }
                               }
                           },



                       }).ToList(),

                      FinalDestinationTradeCountry =  new FinalDestinationTradeCountry() { Id = new List<Id>(){ new Id() { Content = details.FinalTradingCountryCode } }

,


                   },


               },




}
            };
            if( await AddingConsignments(currentObject)){
                return currentObject;
            }
            else
            {
                return null;
            }

        }
        public static async Task<bool> AddingEmptyContainer(EmptyContainerRequest details)
        {
            var currentObject = new ExchangeDataPiplineDTO()
            {
                ExchangedDocument = new ExchangedDocument()
                {
                    IssueDateTime = DateTime.Now,
                    Issuer = new Issuer()
                    {
                        Id = new List<Id>() { new Id() { Content = details.IssuerID } }
                    },
                    RoleCode = new List<RoleCode>()
                      {
                          new RoleCode() {Content = details.TypeCode}
                      }

                },
                ExchangedDeclaration = new ExchangedDeclaration()
                {
                    Id = new List<Id>()
                    {
                         new Id(){ Content = details.UCR}
                      },
                    TypeCode = new DTOS.TypeCode()
                    {
                        Content = "13"

                    },
                    Declarant = new Declarant()
                    {
                        Id = new List<Id>()
                     {
                         new Id(){ Content =details.ReciverID},
                     }
                    }


                },
                SpecifiedLogisticsTransportMovement = new List<SpecifiedLogisticsTransportMovement>()
                {
                    
                    new SpecifiedLogisticsTransportMovement()
                    {
                        LoadingEvent = new LoadingEvent()
                        {
                             OccurrenceLogisticsLocation = new OccurrenceLogisticsLocation()
                             {
                                 Id = new List<Id>()
                                 {
                                       new Id() { Content = details.POL}
                                 },
                                 Name = new List<Name>()
                                 {
                                     new Name() {Content =details.POL}
                                 }
                             },
                                ScheduledOccurrenceDateTime= details.POLEvent
                        } ,
                        UnloadingEvent = new UnloadingEvent()
                        {
                             OccurrenceLogisticsLocation = new OccurrenceLogisticsLocation()
                             {
                                 Id = new List<Id>()
                                 {
                                     new Id() {Content = details.POD}
                                 },
                                 Name =new List<Name>()
                                 {
                                     new Name() {Content =details.POD}
                                 }
                             },
                             ScheduledOccurrenceDateTime= details.POLEvent
                        },
                        UsedLogisticsTransportMeans = new UsedLogisticsTransportMeans()
                        {
                             Id = new List<Id>()
                             {
                                  new Id(){ Content = details.TradingCountryIsoCode}
                             },
                             Name = new Name()
                             {
                                  Content = details.TradingCountryIsoCode
                             },
                             RegistrationTradeCountry = new RegistrationTradeCountry()
                             {
                                 Id = new List<Id>()
                                 {
                                    new Id(){ Content = details.TradingCountryIsoCode}
                                 },
                                 Name = new List<Name>()
                                 {
                                      new Name(){ Content = details.TradingCountryIsoCode}
                                 }
                             }
                             
                            

                        }
                    }
                },
                SpecifiedConsignment = new List<SpecifiedConsignment>()
                {
                    new SpecifiedConsignment()
                    {
                        Id = new List<Id>()
                        {
                             new Id() { Content = details.UCR}
                        }
                        ,
                        TransportContractReferencedDocument = new TransportContractReferencedDocument()
                        {
                            Id = new List<Id>()
                            {
                                new Id() {Content = details.ShippingOrderNumber}
                            }
                        },
                       
                        UtilizedLogisticsTransportEquipment = details.ContainerDetails.Select(a=> new UtilizedLogisticsTransportEquipment()
                        {
                          Id = new Id()
                          {
                              Content =a.ContainerNumber,
                          },
                            UsedCapacityCode =new UsedCapacityCode()
                            {
                                     Content = a.UsedCapacityCode
                            },
                            OperationalStatusCode = new OperationalStatusCode()
                            {
                                Content =a.OperationalStatusCode
                            },
                              GrossWeight = new GrossWeight()
                              {
                                  Content = a.GrossWeight,
                                  UnitCode = a.GrossWeightType


                              } , 
                              AffixedLogisticsSeal = a.ContainerSeals.Select(b=> new AffixedLogisticsSeal()
                              {
                                    Id = new List<Id>()
                                    {
                                        new Id(){ Content = b.Serial.ToString()}
                                    },
                                    SealingPartyRoleCode = new AffixedLogisticsSealId()
                                    {
                                        Content = b.ConditionCode
                                    }
                              }).ToList(),
                             TareWeight = new TareWeight()
                             {
                                 Content = a.TareWeight,
                                 UnitCode = a.TareWeightType
                             },
                             CharacteristicCode = new CharacteristicCode()
                             {
                                 Content = a.ContainerType
                             }

                        }).ToList()


                    },


                },



            };

           return await AddingConsignments(currentObject);
        }

        public static async Task<bool> AddingConsignments(ExchangeDataPiplineDTO exchangeDataPipline)
        {
            Authication authication = new Authication();
            var authResult = await authication.SignIn(AuthicationType.WaypointSubmit);
            string url = $"{ConfigurationManager.AppSettings["MTS_URL"]}/api/v1/consignments/waypoints";
            using (var http = new HttpClient())
            {

                http.DefaultRequestHeaders.Add("Authorization", $"Bearer {authResult.AccessToken}");
                http.DefaultRequestHeaders.Add("Accept", "application/json");
                http.DefaultRequestHeaders.Add("Idempotency-Key", Guid.NewGuid().ToString());
                http.DefaultRequestHeaders.Add("requestId", Guid.NewGuid().ToString());
                var requestBody = JsonConvert.SerializeObject(exchangeDataPipline , new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return true;
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(result);
                }


            }
        }

        public static async Task<bool> BOL(BolInformation bolInformation)
        {
            var currentObject = new ExchangeDataPiplineDTO()
            {
                ExchangedDocument = new ExchangedDocument()
                {
                    IssueDateTime = DateTime.UtcNow,
                    Issuer = new Issuer() { Id = new List<Id>() { new Id() { Content = bolInformation.IssuerID } } },
                    RoleCode = new List<RoleCode>()
                    {
                        new RoleCode() {Content = "DEG"}
                    }

                },
                ExchangedDeclaration = new ExchangedDeclaration()
                {
                    Id = new List<Id>()
                    {
                         new Id(){ Content = bolInformation.UCR}
                      },
                    TypeCode = new DTOS.TypeCode()
                    {
                        Content = bolInformation.BolTypeString,
                    },
                    Declarant = new Declarant()
                    {
                        Id = new List<Id>()
                     {
                         new Id(){ Content =bolInformation.ShipperTaxID},
                     }
                    }
                },
                SpecifiedLogisticsTransportMovement = new List<SpecifiedLogisticsTransportMovement>()
                 {
                      new SpecifiedLogisticsTransportMovement()
                      {
                          LoadingEvent = new LoadingEvent()
                          {
                              ScheduledOccurrenceDateTime = DateTime.Now,
                              OccurrenceLogisticsLocation = new OccurrenceLogisticsLocation()
                              {
                                   
                                  Id = new List<Id>()
                                  {
                                      new Id() { Content = bolInformation.PortOfLoadingCode}
                                  },
                                  Name = new List<Name>()
                                  {
                                        new Name() {Content =  bolInformation.PortOfLoadingName}
                                  }
                              }
                          },
                          UnloadingEvent = new UnloadingEvent()
                          {
                              ScheduledOccurrenceDateTime = bolInformation.ETA,
                              OccurrenceLogisticsLocation = new OccurrenceLogisticsLocation()
                              {
                                  Id = new List<Id>()
                                  {
                                      new Id() { Content = bolInformation.PortOfDischargeCode}
                                  },
                                  Name = new List<Name>()
                                  {
                                        new Name() {Content = bolInformation.PortOfDischargeName}
                                  }

                              },

                          },
                          DepartureEvent = new List<DepartureEvent>()
                          {
                               new DepartureEvent()
                               {
                                    ActualOccurrenceDateTime = DateTime.Now,
                               }
                          },
                          UsedLogisticsTransportMeans = new UsedLogisticsTransportMeans()
                          {
                                Id = new List<Id>()
                                {
                                    new Id() { Content =bolInformation.VesselImo}
                                },
                                Name = new Name()
                                {
                                    Content = bolInformation.VesselTitle
                                },

                          },
                          ArrivalEvent = new List<ArrivalEvent>()
                          {
                              new ArrivalEvent()
                                {
                                    EstimatedOccurrenceDateTime = DateTime.Now,
                                }
                          }



                      },

                 },
                SpecifiedConsignment = new List<SpecifiedConsignment>()
                 {
                        new SpecifiedConsignment()
                        {

                            Id = new List<Id>()
                            {
                                new Id() { Content = bolInformation.UCR}
                            },
                            GrossWeight = bolInformation.GrossWeights.Select(a=> new GrossWeight() { Content = a.TotalGrossWeight , UnitCode = a.UnitTypeGrossWeight}).ToList(),
                               GrossVolumns = bolInformation.GrossVolumn.Select(a=> new GrossVolumn() { Content = a.Value , UnitCode = a.UnitCode}).ToList(),
                            Carrier = new Carrier()
                            {
                                Id = new List<Id>()
                                {
                                    new Id() { Content = bolInformation.CarrierID}
                                },
                                Name = new List<Name>()
                                {
                                    new Name() {Content =  bolInformation.CarrierName}
                                }
                            },
                            FinalDestinationTradeCountry = new FinalDestinationTradeCountry()
                            {
                                Id = new List<Id>()
                                {
                                    new Id() { Content = bolInformation.FinalDestinationCountry}
                                }
                            },
                           Consignee = new Consignee()
                                {
                                    Id = new List<Id>()
                                    {
                                        new Id() { Content = bolInformation.ConsgineeTaxCode },

                                    },
                                    Name = new List<Name>()
                                    {
                                        new Name() { Content = bolInformation.ConsgineeName }
                                    },

                                    PostalTradeAddress= new PostalTradeAddress()
                                    {
                                        CityName = new List<CityName>()
                                        {
                                            new CityName() { Content = bolInformation.ConsigneeCity }
                                        },
                                        CountryId = new CountryId()
                                        {
                                            Content =bolInformation.ConsigneeCountryCode
                                        },

                                    },



                            },
                           ConsignmentItemQuantity = new ConsignmentItemQuantity()
                            {
                                    Content = bolInformation.TotalQuantity

                             },
                           ExportTradeCountry = new ExportTradeCountry()
                           {
                                Id = new List<Id>()
                                {
                                    new Id() { Content =bolInformation.ExporterTradCountry}
                                }
                           },
                           
                           IncludedConsignmentItem = bolInformation.ShippingOrderInformation.Select((line,index) => new IncludedConsignmentItem()
                           {
                               SequenceNumeric = new SequenceNumeric()
                               {
                                   Content   =(index+1) .ToString()
                               },
                               GrossWeight = new List<GrossWeight>()
                               {
                                    new GrossWeight(){ Content =  line.GrossWeight , UnitCode = line.GrossWeightUnitType}
                               },
                               GrossVolumn = new  List<GrossVolumn>()
                               {
                                    new GrossVolumn(){ Content =  line.GrossVolumn , UnitCode = line.GrossVolumnUnitType}
                               },
                               TypeCode = new TypeCode()
                               {
                                   Content = line.CommodityCode
                               },


                               NatureIdCargo = new List<NatureIdCargo>()
                               {
                                   new NatureIdCargo() {Content=line.CargoDescription}
                               },
                               PhysicalLogisticsShippingMarks = new List<PhysicalLogisticsShippingMark>()
                               {
                                   new PhysicalLogisticsShippingMark()
                                   {
                                       Marking =new List<Marking>()
                                       {
                                           new Marking()
                                           {
                                               Content = $"{line.PackageNumber} X {line.PackageType} "
                                           }
                                       }
                                   }
                               },

                           }).ToList(),
                           TransportContractReferencedDocument = new TransportContractReferencedDocument()
                           {
                                Id = new List<Id>()
                                {
                                    new Id() { Content = bolInformation.BolNumber}
                                 }
                            },
                          UtilizedLogisticsTransportEquipment = bolInformation.ContainerInformation.Select(b=> new UtilizedLogisticsTransportEquipment()
                          {
                                   Id = new Id()
                                   {
                                       Content =b.ContainerNo
                                   },
                                   CharacteristicCode = new CharacteristicCode(){
                                        Content = b.ContainerType
                                   },
                                    GrossWeight = new GrossWeight()
                                    {
                                        Content = b.GrossWeight,
                                        UnitCode = b.UnitTypeOfGrossWeight
                                    },
                                    
                                    
                              
                                    AffixedLogisticsSeal = b.ContainerSeals.Select((a)  =>

                                         new AffixedLogisticsSeal()
                                         {
                                              Id = new List<Id>()
                                              {
                                                  new Id() { Content = a.Serial}
                                              },
                                             
                                         }
                                    ).ToList()


                         }).ToList()


                },


            }

            };
            




        
           
            return await AddingConsignments(currentObject);
        }

        public static async Task<bool> UploadMainfest(string filePath)
        {
            Authication authication = new Authication();
            var authResult = await authication.SignIn(AuthicationType.ManifestExport);
            string ediContent = System.IO.File.ReadAllText(filePath, Encoding.UTF8);
            using (var client = new HttpClient())
            using (var form = new MultipartFormDataContent())
            using (var fileStream = System.IO.File.OpenRead(filePath))
            {
                string url = $"{ConfigurationManager.AppSettings["MTS_URL"]}/api/v1/manifests";

                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authResult.AccessToken}");
                client.DefaultRequestHeaders.Add("Idempotency-Key", Guid.NewGuid().ToString());
                form.Add(fileContent, "ediFile", Path.GetFileName(filePath));

                var response = await client.PostAsync(url, form);
                var responseText = await response.Content.ReadAsStringAsync();

             
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    throw new HttpRequestException(responseText);
                }

             
            }
        }
    }
    }

