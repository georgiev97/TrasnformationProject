using Data.DataContext;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class WorkoutRepository : BaseRepository<Workout>
    {

        public WorkoutRepository(TransformationContext context) : base(context)
        {
            
        }
}
}
