/*
 * Author: Johan Ahlqvist
 * Edited for Get and Update: Tobias Svensson
 */

using JulietBlazorApp.Services.Base;

namespace JulietBlazorApp.Services
{
    public interface IMäklareDtoService
    {
        Task<MäklareDto> GetMäklareAsync(string mäklarId);
        Task UpdateMäklareAsync(MäklareDto mäklareDto, string mäklarId);
    }
}