// ************************************************************************************
// WEB524 Project Template V1 2221 == b142f793-ce9d-46e9-b440-906aa0031b02
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
using W2022A3PGBNGUYEN.EntityModels;
using W2022A3PGBNGUYEN.Models;

namespace W2022A3PGBNGUYEN.Controllers
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
                cfg.CreateMap<Album, AlbumBaseViewModel>();
                cfg.CreateMap<Artist, ArtistBaseViewModel>();
                cfg.CreateMap<MediaType, MediaTypeBaseViewModel>();
                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Track, TrackWithDetailViewModel>();
                cfg.CreateMap<TrackWithDetailViewModel, Track >();               
                cfg.CreateMap<TrackAddViewModel, Track>();
                cfg.CreateMap<TrackAddFormViewModel, TrackAddViewModel>();
                cfg.CreateMap<Playlist, PlaylistBaseViewModel>();
                cfg.CreateMap<Playlist, PlaylistWithTracksViewModel>();
                cfg.CreateMap<Playlist, PlaylistEditTracksViewModel>();


                cfg.CreateMap<PlaylistWithTracksViewModel, PlaylistEditTracksFormViewModel>();




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

        //Album functions
        public IEnumerable<AlbumBaseViewModel> AlbumGetAll()
        {
            var myAlbums = ds.Albums.OrderBy(a => a.Title);
                            
            return myAlbums == null ? null : mapper.Map<IEnumerable<Album>, IEnumerable<AlbumBaseViewModel>>(myAlbums);
        }

        //Artist funtions
        public IEnumerable<ArtistBaseViewModel> ArtistGetAll()
        {
            var myArtist = ds.Artists.OrderBy(a => a.Name);

            return myArtist == null ? null : mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistBaseViewModel>>(myArtist);
        }

        //Mediatype function
        public IEnumerable<MediaTypeBaseViewModel> MediaTypeGetAll()
        {
            var myMediaTypes = ds.MediaTypes.OrderBy(m => m.Name);

            return myMediaTypes == null ? null : mapper.Map<IEnumerable<MediaType>, IEnumerable<MediaTypeBaseViewModel>>(myMediaTypes);
        }

        //Track Functions
        public IEnumerable<TrackWithDetailViewModel> TrackGetAllWithDetail()
        {
            var myTracks = ds.Tracks.Include("Album.Artist").Include("Album").Include("MediaType").OrderBy(t => t.Name);

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(myTracks);
        }
        public TrackWithDetailViewModel TrackGetById(int id)
        {
            var myTrack = ds.Tracks.Include("Album.Artist").Include("Album").Include("MediaType").FirstOrDefault(t => t.TrackId== id);
            return myTrack == null ? null : mapper.Map<Track, TrackWithDetailViewModel>(myTrack);
        }


        public TrackWithDetailViewModel TrackAdd(TrackAddViewModel newItem)
        {
            // When adding an object with a required to-one association,
            // MUST fetch the associated object first
        
            // Attempt to find the associated object
            var album = ds.Albums.Find(newItem.AlbumId);
            var mediaType = ds.MediaTypes.Find(newItem.MediaTypeId);
            if (album == null)
            {
                return null;
            }
            else
            {
                // Attempt to add the new item
                var addedItem = ds.Tracks.Add(mapper.Map<TrackAddViewModel, Track>(newItem));

                // Set the associated item property
                addedItem.Album = album;
                addedItem.MediaType = mediaType;
                ds.SaveChanges();

                return (addedItem == null) ? null : mapper.Map<Track, TrackWithDetailViewModel>(addedItem);
            }
        }

        //Playlist functions
        public IEnumerable<PlaylistBaseViewModel> PlaylistGetAll()
        {
            var myPlaylist = ds.Playlists.Include("Tracks").OrderBy(p => p.Name);
            return myPlaylist == null ? null : mapper.Map<IEnumerable<Playlist>, IEnumerable<PlaylistBaseViewModel>>(myPlaylist);
        }
        public PlaylistWithTracksViewModel PlaylistGetById(int id)
        {
            var myPlaylist = ds.Playlists.Include("Tracks").SingleOrDefault(p => p.PlaylistId == id);
                    
         
            return myPlaylist == null ? null : mapper.Map<Playlist, PlaylistWithTracksViewModel>(myPlaylist);
        }
        public PlaylistEditTracksViewModel PlaylistEditTracks(PlaylistEditTracksViewModel newItem)
        {
            var o = ds.Playlists.Include("Tracks").SingleOrDefault(t => t.PlaylistId  == newItem.PlaylistId);

            if (o == null)
            {
                // Problem - object was not found, so return
                return null;
            }
            else
            {
                // Update the object with the incoming values

                // First, clear out the existing collection
                o.Tracks.Clear();

                // Then, go through the incoming items
                // For each one, add to the fetched object's collection
                foreach (var item in newItem.TrackIds)
                {
                    var a = ds.Tracks.Find(item);
                    o.Tracks.Add(a);
                }
                // Save changes
                ds.SaveChanges();

                return mapper.Map<Playlist, PlaylistEditTracksViewModel>(o);
            }
        }
    }
}