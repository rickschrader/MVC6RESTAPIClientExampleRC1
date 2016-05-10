﻿using System;
using Microsoft.AspNet.Mvc;
using MVC6ApiClientExample.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC6ApiClientExample.Controllers
{
    public class AlbumsController : Controller
    {
        //TODO: DI for this
        string _baseUrl = "http://localhost:8000/api/albums/";

        public AlbumsController()
        {

        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            //TODO: DI for url, etc
            var requestUrl = _baseUrl;
            var httpClient = new HttpClient();

            List<Album> albums;

            using (var response = await httpClient.GetAsync(requestUrl))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.Content));
                }

                var json = await response.Content.ReadAsStringAsync();
                albums = JsonConvert.DeserializeObject(json, typeof(List<Album>)) as List<Album>;
            }

            return View(albums);
        }

        public async Task<IActionResult> Detail(string id)
        {
            //TODO: DI for url, etc
            var requestUrl = _baseUrl + id;
            var httpClient = new HttpClient();

            Album album;

            using (var response = await httpClient.GetAsync(requestUrl))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.Content));
                }

                var json = await response.Content.ReadAsStringAsync();
                album = JsonConvert.DeserializeObject(json, typeof(Album)) as Album;
            }

            return View(album);
        }

        //public async Task<IActionResult> Edit(string id)
        //{

        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(Album album)
        //{
        
        //}
        
        public async Task<IActionResult> Delete(string id)
        {
            var requestUrl = _baseUrl + id;
            var httpClient = new HttpClient();

            //Album album;

            //TODO: Prompt to confirm delete?

            using (var response = await httpClient.DeleteAsync(requestUrl))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.Content));
                }

                //var json = await response.Content.ReadAsStringAsync();
                //album = JsonConvert.DeserializeObject(json, typeof(Album)) as Album;
            }

            //Refresh the list
            return RedirectToAction("Index");
        }


        //public async Task<IActionResult> Create()
        //{
        //    
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Album album)
        //{

        //}

    }
}
