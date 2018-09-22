using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MurderWithFriendsAPI.DAL.Models;
using MurderWithFriendsAPI.Data.DTO;

namespace MurderWithFriendsAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
            CreateMappings();
            CreateWebHostBuilder(args).Build().Run();

		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();

        public static void CreateMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
           {
               cfg.CreateMap<Character, CharacterDTO>();
               cfg.CreateMap<CurrencyType, CurrencyTypeDTO>();
               cfg.CreateMap<Equipment, EquipmentDTO>();
               cfg.CreateMap<Experience, ExperienceDTO>();
               cfg.CreateMap<Item, ItemDTO>();
               cfg.CreateMap<ItemType, ItemTypeDTO>();
               cfg.CreateMap<LoginHistory, LoginHistoryDTO>();
               cfg.CreateMap<LoginResult, LoginResultDTO>();
               cfg.CreateMap<Security, SecurityDTO>();
               cfg.CreateMap<Stats, StatsDTO>();
               cfg.CreateMap<User, UserDTO>();
               cfg.CreateMap<UserCurrency, UserCurrencyDTO>();

           });

        }
	}
}
