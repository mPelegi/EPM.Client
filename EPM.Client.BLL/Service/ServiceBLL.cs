using EPM.Client.BLL.Base;
using EPM.Client.Models.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Client.BLL.Service
{
    public class ServiceBLL : BaseBLL
    {
        public void Start()
        {
            DescriptionBLL descriptionBLL = new DescriptionBLL();
            ConsumeWebAPI(descriptionBLL.CreateReport());
        }


        public void StartMonitoring()
        {
            PerformanceBLL performanceBLL = new PerformanceBLL();
            ConsumeWebAPI(performanceBLL.CreateReport());
        }

        private void ConsumeWebAPI(DescriptionDTO descricao)
        {
            string resource = "api/monitor/description";
            RestClient restClient = new RestClient("https://localhost:44318/");
            RestRequest request = new RestRequest(resource, Method.POST);
            //request.AddHeader("Token");
            request.AddJsonBody(descricao);

            IRestResponse response = restClient.Execute(request);

            if (response.IsSuccessful)
            {
            }
        }

        private void ConsumeWebAPI(PerformanceDTO performance)
        {
            string resource = "api/monitor/performance";
            RestClient restClient = new RestClient("https://localhost:44318/");
            RestRequest request = new RestRequest(resource, Method.POST);
            //request.AddHeader("Token");
            request.AddJsonBody(performance);

            IRestResponse response = restClient.Execute(request);

            if (response.IsSuccessful)
            {
            }
        }
    }
}
