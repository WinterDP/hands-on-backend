﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EventsLogger.Dto.RelationshipUserEntryProject
{
    public class CreateRelationshipUserEntryProjectDTO
    {
        public Guid? ProjectId { get; init; }
        public Guid? UserId { get; init; }
        public Guid? EntryId { get; init; }
        public DateOnly CreatedDate { get; set; }
    }
}
