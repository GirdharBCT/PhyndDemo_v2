using PhyndDemo_v2.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.Managers
{
    public interface IProgramRepository
    {
        IEnumerable<Models.Program> GetPrograms();
        Models.Program GetProgram(int id);
        void AddProgram(Models.Program program);
        void Update(Models.Program program, ProgramDTO programDTO);
        void DeleteProgram(Models.Program program);

    }
}
