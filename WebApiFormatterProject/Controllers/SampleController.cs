using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using WebApiFormatterProject.Models;

namespace WebApiFormatterProject.Controllers
{
	public class SampleController : ApiController
	{
		private SampleDataRepository _repository;

		public SampleController() : this(new SampleDataRepository()) { }

		public SampleController(SampleDataRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public List<SampleObject> GiveMeData()
		{
			return _repository.GetData();
		}

		[HttpGet]
		public HttpResponseMessage GiveMeDataInJSON()
		{
			var data = _repository.GetData();

			return Request.CreateResponse<List<SampleObject>>(HttpStatusCode.OK, data, new JsonMediaTypeFormatter());
		}

		[HttpGet]
		public HttpResponseMessage GiveMeDataInXML()
		{
			var data = _repository.GetData();

			return Request.CreateResponse<List<SampleObject>>(HttpStatusCode.OK, data, new XmlMediaTypeFormatter());
		}
	}

	public class SampleDataRepository
	{
		public List<SampleObject> GetData()
		{
			return new List<SampleObject>() { 
				new SampleObject(){ Id = 1, Name = "One" , Description="Sample One"},
				new SampleObject(){ Id = 2, Name = "Two" , Description="Sample Two"},
				new SampleObject(){ Id = 3, Name = "Three" , Description="Sample Three"},
				new SampleObject(){ Id = 4, Name = "Four" , Description="Sample Four"}
			};
		}
	}

}