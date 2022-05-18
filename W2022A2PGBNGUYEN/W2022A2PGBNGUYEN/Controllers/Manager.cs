// ************************************************************************************
// WEB524 Project Template V1 2221 == 1e8b3e60-e824-4482-b99a-ca3606adbb03
// Do not change or remove the line above.
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W2022A2PGBNGUYEN.EntityModels;
using W2022A2PGBNGUYEN.Models;

namespace W2022A2PGBNGUYEN.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();
                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Invoice, InvoiceBaseViewModel>();
                cfg.CreateMap<InvoiceLine, InvoiceLineWithDetailViewModel>();
                cfg.CreateMap<Invoice, InvoiceWithDetailViewModel>();
                cfg.CreateMap<Invoice, InvoiceLineWithDetailViewModel>();

            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().
        public IEnumerable<TrackBaseViewModel> TrackGetAll() {
            var myTrack = ds.Tracks.OrderBy(t => t.Name)
                            .ThenBy(t => t.Composer);
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(myTrack);
        }
        public IEnumerable<TrackBaseViewModel> TrackGetAllRockMetal()
        {
            var myTrack = ds.Tracks.Where(t => t.GenreId == 1 || t.GenreId == 3)
                            .OrderBy(t => t.Name)
                            .ThenBy(t => t.Composer);
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(myTrack);
        }
        public IEnumerable<TrackBaseViewModel> TrackGetAllTylerVallance()
        {
            var myTrack = ds.Tracks.Where(t => t.Composer.Contains("Steven Tyler")  || t.Composer.Contains("Jim Vallance"))
                                   .OrderBy(t => t.Composer)
                                   .ThenBy(t => t.Name);
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(myTrack);
        }
        public IEnumerable<TrackBaseViewModel> TrackGetAllTop50Longest()
        {
            var myTrack = ds.Tracks
                            .OrderByDescending(t => t.Milliseconds)
                            .Take(50);
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(myTrack);
        }
        public IEnumerable<TrackBaseViewModel> TrackGetAllTop50Smallest()
        {
            var myTrack = ds.Tracks
                            .OrderBy(t => t.Bytes)
                            .Take(50);
                           
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(myTrack);
        }
        public IEnumerable<InvoiceBaseViewModel> InvoiceGetAll()
        {
            var myInvoice = ds.Invoices;
            return mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceBaseViewModel>>(myInvoice);
        }
        public InvoiceBaseViewModel InvoiceGetById(int id)
        {
            var myInvoice = ds.Invoices.Find(id);
            return mapper.Map<Invoice, InvoiceBaseViewModel>(myInvoice);
        }
        public InvoiceWithDetailViewModel InvoiceGetByIdWithDetail(int id)
        {
            var myInvoice = ds.Invoices
                              .Include("Customer.Employee")
                              .Include("InvoiceLines.Track.Album.Artist")   
                              .Include("InvoiceLines.Track.MediaType")
                              .SingleOrDefault(i => i.InvoiceId==id);
            return mapper.Map<Invoice, InvoiceWithDetailViewModel>(myInvoice);
        }
    }
}