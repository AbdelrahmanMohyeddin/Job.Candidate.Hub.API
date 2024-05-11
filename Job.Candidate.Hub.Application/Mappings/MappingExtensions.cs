using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Job.Candidate.Hub.Application.Models.Response;

namespace Job.Candidate.Hub.Application.Mappings
{
    public static class MappingExtensions
    {
        public static async Task<GenericListQueryResponse<TDestination>> ProjectToGenericListQueryResponseAsync<TSource, TDestination>
            (this IQueryable<TSource> source, IMapper mapper, int? pageNumber = null, int? pageSize = null) where TSource : class where TDestination : class
        {
            source = source.AsNoTracking();

            var count = await source.CountAsync();

            TDestination[] items;

            if (pageSize.HasValue && pageNumber.HasValue)
            {

                items = mapper.Map<TDestination[]>(source.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value));
            }
            else
            {

                items = mapper.Map<TDestination[]>(source);
            }

            return new GenericListQueryResponse<TDestination>(items, count);
        }


        public static GenericListQueryResponse<TDestination> ProjectToGenericListQueryResponse<TSource, TDestination>
          (this IQueryable<TSource> source, IMapper mapper, int? pageNumber = null, int? pageSize = null) where TSource : class where TDestination : class
        {
            source = source.AsNoTracking();

            var count = source.Count();

            TDestination[] items;

            if (pageSize.HasValue && pageNumber.HasValue)
            {

                items = mapper.Map<TDestination[]>(source.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value));
            }
            else
            {

                items = mapper.Map<TDestination[]>(source);
            }

            return new GenericListQueryResponse<TDestination>(items, count);
        }


        public static async Task<GenericResponse<TDestination>> ProjectToGenericResponseAsync<TSource, TDestination>
         (this IQueryable<TSource> source, IMapper mapper) where TSource : class where TDestination : class
        {
            var entity = await source
                .AsNoTracking()
                .FirstOrDefaultAsync();


            return new GenericResponse<TDestination>
            {
                Result = mapper.Map<TDestination>(entity)
            };
        }


    }
}
