using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class MentorService(DataContext context) : IMentorService
{
    public async Task<Response<string>> CreateMentorAsync(Mentor mentor)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"INSERT INTO Mentors (FullName, Email, Phone, Specialization)
                            VALUES (@FullName, @Email, @Phone, @Specialization)";
            var result = await connection.ExecuteAsync(cmd, mentor);
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "Mentor successfully created");
        }
    }

    public async Task<Response<List<Mentor>>> GetAllMentorsAsync()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select * from Mentors";
            var result = await connection.QueryAsync<Mentor>(cmd);
            return new Response<List<Mentor>>(result.ToList(), "Mentors retrieved successfuly");
        }
    }

    public async Task<Response<Mentor?>> GetMentorByIdAsync(int id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select * from Mentors where id = @id";
            var result = await connection.QueryFirstOrDefaultAsync<Mentor>(cmd, new { id = id });
            if (result == null)
            {
                return new Response<Mentor?>("Book not found", HttpStatusCode.NotFound);
            }
            return new Response<Mentor?>(result, "Book successfully retrieved");
        }
    }

    public async Task<Response<string>> UpdateMentorAsync(Mentor mentor)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = $@"Update Mentors set 
                        fullName = @fullName, email = @email, phone = @phone, Specialization = @Specialization 
                        where id = @id";
            var result = await connection.ExecuteAsync(cmd, mentor);
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "Mentor successfully updated");
        }
    }

    public async Task<Response<string>> DeleteMentorAsync(int id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = $@"Delete from Mentors Where id = @id";
            var result = await connection.ExecuteAsync(cmd, new { id = id });
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "Mentors successfully deleted");
        }
    }
}
