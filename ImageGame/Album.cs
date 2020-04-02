using System;
using System.Collections.Generic;
using System.Text;

namespace ImageGame
{

    public class AlbumData
    {
        public Album[] Albums { get; set; }
        public string NextPageToken { get; set; }
    }

    public class Album
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ProductUrl { get; set; }
        public string CoverPhotoBaseUrl { get; set; }
        public string CoverPhotoMediaItemId { get; set; }
        public string IsWriteable { get; set; }
        public string MediaItemsCount { get; set; }
    }

}
