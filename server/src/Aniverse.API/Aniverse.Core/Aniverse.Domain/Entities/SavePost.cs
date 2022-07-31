﻿using Aniverse.Domain.Entities.Common;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Domain.Entities
{
    public class SavePost : IBaseEntity<Guid>, ICreatedDate
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public DateTime CreatedDate { get ;set ;}
        public Guid Id { get; set; }
    }
}
