﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Common.Exeptions;
using StudentProfile.Application.Interfaces;
using StudentProfile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudentProfile.Application.Events.Commnad.RemoveStudentsForEvent
{
    public class RemoveStudentForEventCommandHandler
        : IRequestHandler<RemoveStudentForEventCommand>
    {

        private readonly IStudentProfileContext _dbContext;

        public RemoveStudentForEventCommandHandler(IStudentProfileContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(RemoveStudentForEventCommand request, CancellationToken cancellationToken)
        {
            var @event = await _dbContext.Events.Include(x => x.Skills).FirstOrDefaultAsync(@event => @event.Id == request.EventId);

            if (@event == null)
                throw new NotFoundException(nameof(Event), request.EventId);

            var student = await _dbContext.Students.Include(events => events.Events).Include(s => s.Skills).FirstOrDefaultAsync(student => student.Id == request.StudentId);

            if (student == null)
                throw new NotFoundException(nameof(Student), request.StudentId);

            if (@event.Skills != null)
            {
                foreach (var skill in @event.Skills)
                {
                    student.Skills.Remove(skill);
                }
            }

            student.Events.Remove(@event);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
