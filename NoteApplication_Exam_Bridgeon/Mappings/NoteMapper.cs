using AutoMapper;
using NoteApplication_Exam_Bridgeon.Entities.Models.DTO;
using NoteApplication_Exam_Bridgeon.Entities.Models.NoteModels;
using NoteApplication_Exam_Bridgeon.Entities.Models.UserModels;

namespace NoteApplication_Exam_Bridgeon.Mappings
{
    public class NoteMapper : Profile
    {
        public NoteMapper()
        {
            // User to UserRegisterDTO and vice versa mapping
            CreateMap<Note, NoteInputDTO>();

            CreateMap<User, UserInputDTO>();


        }
    }
}
