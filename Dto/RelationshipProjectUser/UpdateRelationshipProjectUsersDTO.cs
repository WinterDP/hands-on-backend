﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EventsLogger.Dto.RelationshipProjectUser
{
    public class UpdateRelationshipProjectUsersDTO
    {
        public required Guid ProjectId { get; init; }
        public required Guid UserId { get; init; }
        public required string Role { get; set; }
        public DateOnly UpdatedDate { get; set; }
    }
}
