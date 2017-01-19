using System;
using System.Diagnostics;
using NodaTime;
using Moq;
using NodatimeDemo.Services;
using Xunit;
using Should.Fluent;

namespace NodatimeDemo.Tests
{
    public class NodaTimeShould
    {
        private readonly Mock<IClock> _clock;
        private const string EasternTimeZoneIdentifier = "US/Eastern";

        public NodaTimeShould()
        {
            _clock = new Mock<IClock>();
        }

        [Fact]
        public void Get_available_noda_time_zones()
        {
            var provider = DateTimeZoneProviders.Tzdb;
            foreach (var id in provider.Ids)
            {
                Debug.Print(id);
            }
            /*
            Africa/Abidjan
            Africa/Accra
            Africa/Addis_Ababa
            Africa/Algiers
            Africa/Asmara
            Africa/Asmera
            Africa/Bamako
            Africa/Bangui
            Africa/Banjul
            Africa/Bissau
            Africa/Blantyre
            Africa/Brazzaville
            Africa/Bujumbura
            Africa/Cairo
            Africa/Casablanca
            Africa/Ceuta
            Africa/Conakry
            Africa/Dakar
            Africa/Dar_es_Salaam
            Africa/Djibouti
            Africa/Douala
            Africa/El_Aaiun
            Africa/Freetown
            Africa/Gaborone
            Africa/Harare
            Africa/Johannesburg
            Africa/Juba
            Africa/Kampala
            Africa/Khartoum
            Africa/Kigali
            Africa/Kinshasa
            Africa/Lagos
            Africa/Libreville
            Africa/Lome
            Africa/Luanda
            Africa/Lubumbashi
            Africa/Lusaka
            Africa/Malabo
            Africa/Maputo
            Africa/Maseru
            Africa/Mbabane
            Africa/Mogadishu
            Africa/Monrovia
            Africa/Nairobi
            Africa/Ndjamena
            Africa/Niamey
            Africa/Nouakchott
            Africa/Ouagadougou
            Africa/Porto-Novo
            Africa/Sao_Tome
            Africa/Timbuktu
            Africa/Tripoli
            Africa/Tunis
            Africa/Windhoek
            America/Adak
            America/Anchorage
            America/Anguilla
            America/Antigua
            America/Araguaina
            America/Argentina/Buenos_Aires
            America/Argentina/Catamarca
            America/Argentina/ComodRivadavia
            America/Argentina/Cordoba
            America/Argentina/Jujuy
            America/Argentina/La_Rioja
            America/Argentina/Mendoza
            America/Argentina/Rio_Gallegos
            America/Argentina/Salta
            America/Argentina/San_Juan
            America/Argentina/San_Luis
            America/Argentina/Tucuman
            America/Argentina/Ushuaia
            America/Aruba
            America/Asuncion
            America/Atikokan
            America/Atka
            America/Bahia
            America/Bahia_Banderas
            America/Barbados
            America/Belem
            America/Belize
            America/Blanc-Sablon
            America/Boa_Vista
            America/Bogota
            America/Boise
            America/Buenos_Aires
            America/Cambridge_Bay
            America/Campo_Grande
            America/Cancun
            America/Caracas
            America/Catamarca
            America/Cayenne
            America/Cayman
            America/Chicago
            America/Chihuahua
            America/Coral_Harbour
            America/Cordoba
            America/Costa_Rica
            America/Creston
            America/Cuiaba
            America/Curacao
            America/Danmarkshavn
            America/Dawson
            America/Dawson_Creek
            America/Denver
            America/Detroit
            America/Dominica
            America/Edmonton
            America/Eirunepe
            America/El_Salvador
            America/Ensenada
            America/Fort_Nelson
            America/Fort_Wayne
            America/Fortaleza
            America/Glace_Bay
            America/Godthab
            America/Goose_Bay
            America/Grand_Turk
            America/Grenada
            America/Guadeloupe
            America/Guatemala
            America/Guayaquil
            America/Guyana
            America/Halifax
            America/Havana
            America/Hermosillo
            America/Indiana/Indianapolis
            America/Indiana/Knox
            America/Indiana/Marengo
            America/Indiana/Petersburg
            America/Indiana/Tell_City
            America/Indiana/Vevay
            America/Indiana/Vincennes
            America/Indiana/Winamac
            America/Indianapolis
            America/Inuvik
            America/Iqaluit
            America/Jamaica
            America/Jujuy
            America/Juneau
            America/Kentucky/Louisville
            America/Kentucky/Monticello
            America/Knox_IN
            America/Kralendijk
            America/La_Paz
            America/Lima
            America/Los_Angeles
            America/Louisville
            America/Lower_Princes
            America/Maceio
            America/Managua
            America/Manaus
            America/Marigot
            America/Martinique
            America/Matamoros
            America/Mazatlan
            America/Mendoza
            America/Menominee
            America/Merida
            America/Metlakatla
            America/Mexico_City
            America/Miquelon
            America/Moncton
            America/Monterrey
            America/Montevideo
            America/Montreal
            America/Montserrat
            America/Nassau
            America/New_York
            America/Nipigon
            America/Nome
            America/Noronha
            America/North_Dakota/Beulah
            America/North_Dakota/Center
            America/North_Dakota/New_Salem
            America/Ojinaga
            America/Panama
            America/Pangnirtung
            America/Paramaribo
            America/Phoenix
            America/Port-au-Prince
            America/Port_of_Spain
            America/Porto_Acre
            America/Porto_Velho
            America/Puerto_Rico
            America/Rainy_River
            America/Rankin_Inlet
            America/Recife
            America/Regina
            America/Resolute
            America/Rio_Branco
            America/Rosario
            America/Santa_Isabel
            America/Santarem
            America/Santiago
            America/Santo_Domingo
            America/Sao_Paulo
            America/Scoresbysund
            America/Shiprock
            America/Sitka
            America/St_Barthelemy
            America/St_Johns
            America/St_Kitts
            America/St_Lucia
            America/St_Thomas
            America/St_Vincent
            America/Swift_Current
            America/Tegucigalpa
            America/Thule
            America/Thunder_Bay
            America/Tijuana
            America/Toronto
            America/Tortola
            America/Vancouver
            America/Virgin
            America/Whitehorse
            America/Winnipeg
            America/Yakutat
            America/Yellowknife
            Antarctica/Casey
            Antarctica/Davis
            Antarctica/DumontDUrville
            Antarctica/Macquarie
            Antarctica/Mawson
            Antarctica/McMurdo
            Antarctica/Palmer
            Antarctica/Rothera
            Antarctica/South_Pole
            Antarctica/Syowa
            Antarctica/Troll
            Antarctica/Vostok
            Arctic/Longyearbyen
            Asia/Aden
            Asia/Almaty
            Asia/Amman
            Asia/Anadyr
            Asia/Aqtau
            Asia/Aqtobe
            Asia/Ashgabat
            Asia/Ashkhabad
            Asia/Baghdad
            Asia/Bahrain
            Asia/Baku
            Asia/Bangkok
            Asia/Barnaul
            Asia/Beirut
            Asia/Bishkek
            Asia/Brunei
            Asia/Calcutta
            Asia/Chita
            Asia/Choibalsan
            Asia/Chongqing
            Asia/Chungking
            Asia/Colombo
            Asia/Dacca
            Asia/Damascus
            Asia/Dhaka
            Asia/Dili
            Asia/Dubai
            Asia/Dushanbe
            Asia/Gaza
            Asia/Harbin
            Asia/Hebron
            Asia/Ho_Chi_Minh
            Asia/Hong_Kong
            Asia/Hovd
            Asia/Irkutsk
            Asia/Istanbul
            Asia/Jakarta
            Asia/Jayapura
            Asia/Jerusalem
            Asia/Kabul
            Asia/Kamchatka
            Asia/Karachi
            Asia/Kashgar
            Asia/Kathmandu
            Asia/Katmandu
            Asia/Khandyga
            Asia/Kolkata
            Asia/Krasnoyarsk
            Asia/Kuala_Lumpur
            Asia/Kuching
            Asia/Kuwait
            Asia/Macao
            Asia/Macau
            Asia/Magadan
            Asia/Makassar
            Asia/Manila
            Asia/Muscat
            Asia/Nicosia
            Asia/Novokuznetsk
            Asia/Novosibirsk
            Asia/Omsk
            Asia/Oral
            Asia/Phnom_Penh
            Asia/Pontianak
            Asia/Pyongyang
            Asia/Qatar
            Asia/Qyzylorda
            Asia/Rangoon
            Asia/Riyadh
            Asia/Saigon
            Asia/Sakhalin
            Asia/Samarkand
            Asia/Seoul
            Asia/Shanghai
            Asia/Singapore
            Asia/Srednekolymsk
            Asia/Taipei
            Asia/Tashkent
            Asia/Tbilisi
            Asia/Tehran
            Asia/Tel_Aviv
            Asia/Thimbu
            Asia/Thimphu
            Asia/Tokyo
            Asia/Ujung_Pandang
            Asia/Ulaanbaatar
            Asia/Ulan_Bator
            Asia/Urumqi
            Asia/Ust-Nera
            Asia/Vientiane
            Asia/Vladivostok
            Asia/Yakutsk
            Asia/Yekaterinburg
            Asia/Yerevan
            Atlantic/Azores
            Atlantic/Bermuda
            Atlantic/Canary
            Atlantic/Cape_Verde
            Atlantic/Faeroe
            Atlantic/Faroe
            Atlantic/Jan_Mayen
            Atlantic/Madeira
            Atlantic/Reykjavik
            Atlantic/South_Georgia
            Atlantic/St_Helena
            Atlantic/Stanley
            Australia/ACT
            Australia/Adelaide
            Australia/Brisbane
            Australia/Broken_Hill
            Australia/Canberra
            Australia/Currie
            Australia/Darwin
            Australia/Eucla
            Australia/Hobart
            Australia/LHI
            Australia/Lindeman
            Australia/Lord_Howe
            Australia/Melbourne
            Australia/NSW
            Australia/North
            Australia/Perth
            Australia/Queensland
            Australia/South
            Australia/Sydney
            Australia/Tasmania
            Australia/Victoria
            Australia/West
            Australia/Yancowinna
            Brazil/Acre
            Brazil/DeNoronha
            Brazil/East
            Brazil/West
            CET
            CST6CDT
            Canada/Atlantic
            Canada/Central
            Canada/East-Saskatchewan
            Canada/Eastern
            Canada/Mountain
            Canada/Newfoundland
            Canada/Pacific
            Canada/Saskatchewan
            Canada/Yukon
            Chile/Continental
            Chile/EasterIsland
            Cuba
            EET
            EST
            EST5EDT
            Egypt
            Eire
            Etc/GMT
            Etc/GMT+0
            Etc/GMT+1
            Etc/GMT+10
            Etc/GMT+11
            Etc/GMT+12
            Etc/GMT+2
            Etc/GMT+3
            Etc/GMT+4
            Etc/GMT+5
            Etc/GMT+6
            Etc/GMT+7
            Etc/GMT+8
            Etc/GMT+9
            Etc/GMT-0
            Etc/GMT-1
            Etc/GMT-10
            Etc/GMT-11
            Etc/GMT-12
            Etc/GMT-13
            Etc/GMT-14
            Etc/GMT-2
            Etc/GMT-3
            Etc/GMT-4
            Etc/GMT-5
            Etc/GMT-6
            Etc/GMT-7
            Etc/GMT-8
            Etc/GMT-9
            Etc/GMT0
            Etc/Greenwich
            Etc/UCT
            Etc/UTC
            Etc/Universal
            Etc/Zulu
            Europe/Amsterdam
            Europe/Andorra
            Europe/Astrakhan
            Europe/Athens
            Europe/Belfast
            Europe/Belgrade
            Europe/Berlin
            Europe/Bratislava
            Europe/Brussels
            Europe/Bucharest
            Europe/Budapest
            Europe/Busingen
            Europe/Chisinau
            Europe/Copenhagen
            Europe/Dublin
            Europe/Gibraltar
            Europe/Guernsey
            Europe/Helsinki
            Europe/Isle_of_Man
            Europe/Istanbul
            Europe/Jersey
            Europe/Kaliningrad
            Europe/Kiev
            Europe/Lisbon
            Europe/Ljubljana
            Europe/London
            Europe/Luxembourg
            Europe/Madrid
            Europe/Malta
            Europe/Mariehamn
            Europe/Minsk
            Europe/Monaco
            Europe/Moscow
            Europe/Nicosia
            Europe/Oslo
            Europe/Paris
            Europe/Podgorica
            Europe/Prague
            Europe/Riga
            Europe/Rome
            Europe/Samara
            Europe/San_Marino
            Europe/Sarajevo
            Europe/Simferopol
            Europe/Skopje
            Europe/Sofia
            Europe/Stockholm
            Europe/Tallinn
            Europe/Tirane
            Europe/Tiraspol
            Europe/Ulyanovsk
            Europe/Uzhgorod
            Europe/Vaduz
            Europe/Vatican
            Europe/Vienna
            Europe/Vilnius
            Europe/Volgograd
            Europe/Warsaw
            Europe/Zagreb
            Europe/Zaporozhye
            Europe/Zurich
            GB
            GB-Eire
            GMT
            GMT+0
            GMT-0
            GMT0
            Greenwich
            HST
            Hongkong
            Iceland
            Indian/Antananarivo
            Indian/Chagos
            Indian/Christmas
            Indian/Cocos
            Indian/Comoro
            Indian/Kerguelen
            Indian/Mahe
            Indian/Maldives
            Indian/Mauritius
            Indian/Mayotte
            Indian/Reunion
            Iran
            Israel
            Jamaica
            Japan
            Kwajalein
            Libya
            MET
            MST
            MST7MDT
            Mexico/BajaNorte
            Mexico/BajaSur
            Mexico/General
            NZ
            NZ-CHAT
            Navajo
            PRC
            PST8PDT
            Pacific/Apia
            Pacific/Auckland
            Pacific/Bougainville
            Pacific/Chatham
            Pacific/Chuuk
            Pacific/Easter
            Pacific/Efate
            Pacific/Enderbury
            Pacific/Fakaofo
            Pacific/Fiji
            Pacific/Funafuti
            Pacific/Galapagos
            Pacific/Gambier
            Pacific/Guadalcanal
            Pacific/Guam
            Pacific/Honolulu
            Pacific/Johnston
            Pacific/Kiritimati
            Pacific/Kosrae
            Pacific/Kwajalein
            Pacific/Majuro
            Pacific/Marquesas
            Pacific/Midway
            Pacific/Nauru
            Pacific/Niue
            Pacific/Norfolk
            Pacific/Noumea
            Pacific/Pago_Pago
            Pacific/Palau
            Pacific/Pitcairn
            Pacific/Pohnpei
            Pacific/Ponape
            Pacific/Port_Moresby
            Pacific/Rarotonga
            Pacific/Saipan
            Pacific/Samoa
            Pacific/Tahiti
            Pacific/Tarawa
            Pacific/Tongatapu
            Pacific/Truk
            Pacific/Wake
            Pacific/Wallis
            Pacific/Yap
            Poland
            Portugal
            ROC
            ROK
            Singapore
            Turkey
            UCT

            US/Alaska
            US/Aleutian
            US/Arizona
            US/Central
            US/East-Indiana
            US/Eastern
            US/Hawaii
            US/Indiana-Starke
            US/Michigan
            US/Mountain
            US/Pacific
            US/Pacific-New
            US/Samoa

            UTC
            Universal
            W-SU
            WET
            Zulu
            */
        }

        [Fact]
        public void Set_time_zone_to_eastern_using_identifier()
        {
            var provider = DateTimeZoneProviders.Tzdb;
            NodaTime.DateTimeZone easternTimeZone = provider[EasternTimeZoneIdentifier];
        }

        [Fact]
        public void Set_time_zone_to_eastern_using_offset()
        {
            var timeOffset = -5; //Which was retrieved via a provider either for a phone area code or a zip code from TimeZoneAreaCode and TimeZoneZip
            NodaTime.DateTimeZone easternTimeZone = DateTimeZone.ForOffset(Offset.FromHours(timeOffset));
        }

        [Fact]
        public void Compare_multiple_time_zones_for_the_same_time()
        {
            const string easternSaturdayMorning = "10/26/1985 8:00:01 AM";
            ZonedDateTime easternDateTime = GetDateTime(easternSaturdayMorning, EasternTimeZoneIdentifier);

            var pacificTimeZoneIdentifier = "US/Pacific";
            const string pacificSaturdayMorning = "10/26/1985 5:00:01 AM";
            ZonedDateTime pacificDateTime = GetDateTime(pacificSaturdayMorning, pacificTimeZoneIdentifier);

            easternDateTime.ToDateTimeUtc().Ticks.Should().Equal(pacificDateTime.ToDateTimeUtc().Ticks);
        }

        private static ZonedDateTime GetDateTime(string dateTime, string timeZoneIdentifier)
        {
            var dotNetDateTime = DateTime.Parse(dateTime);
            var localDate = LocalDateTime.FromDateTime(dotNetDateTime);
            var easternTimeZone = DateTimeZoneProviders.Tzdb[timeZoneIdentifier];
            return easternTimeZone.AtLeniently(localDate);
        }

        [Fact]
        public void Mock_the_current_now_time_in_the_eastern_time_zone()
        {
            const string saturdayMorning = "10/26/1985 12:00:00 AM";

            var dotNetDateTime = DateTime.Parse(saturdayMorning);
            var localDateTime = LocalDateTime.FromDateTime(dotNetDateTime);

            var easternDateTime = GetDateTime(saturdayMorning, EasternTimeZoneIdentifier);

            //Mock the .Now return
            _clock.Setup(x => x.Now).Returns(Instant.FromDateTimeUtc(easternDateTime.ToDateTimeUtc()));

            var someImplementation = new SomeImplementation(_clock.Object);
            var result = someImplementation.GetNewYorkDateTime();

            result.Should().Equal(localDateTime);
        }

        [Fact]
        public void Get_next_friday()
        {
            const string saturdayMorning = "10/26/1985 12:00:00 AM";
            var dotNetSaturday = DateTime.Parse(saturdayMorning);
            var localDateTimeSaturday = LocalDateTime.FromDateTime(dotNetSaturday);

            const string nextFridayMorning = "11/1/1985 12:00:00 AM";
            var dotNetFriday = DateTime.Parse(nextFridayMorning);
            var localDateTimeFriday = LocalDateTime.FromDateTime(dotNetFriday);

            /*
            The ISO week date system is effectively a leap week calendar 
            system that is part of the ISO 8601 
            date and time standard issued by the 
            International Organization for Standardization(ISO)
            since 1988 (last revised in 2004) 
            and, before that, it was defined in ISO(R) 2015 since 1971.
            */
            var nextFriday = localDateTimeSaturday.Next(IsoDayOfWeek.Friday);

            nextFriday.Should().Equal(localDateTimeFriday);
        }

        [Fact]
        public void Go_back_in_time()
        {
            var today = new LocalDateTime(1985, 10, 26, 1, 35);
            var redLetterDay = new LocalDateTime(1955, 11, 5, 6, 15);

            var period = Period.Between(redLetterDay, today, PeriodUnits.AllUnits);

            //Note: Go 88mph
            today = today - period;

            today.Should().Equal(redLetterDay);
        }

        [Fact]
        public void Go_back_to_the_future()
        {
            var today = new LocalDateTime(1955, 11, 12, 22, 04);
            var backToTheFuture = new LocalDateTime(1985, 10, 26, 1, 24);

            var period = Period.Between(today, backToTheFuture, PeriodUnits.AllUnits);

            //Note: Go 88mph + 1.21 gigawatts from lightning
            today = today + period;

            today.Should().Equal(backToTheFuture);
        }

        [Fact]
        public void Add_month_to_january()
        {
            const string january31St = "1/31/2017 12:00:00 AM";
            var dotNetJanuary31St = DateTime.Parse(january31St);
            var nodaTimeJanuary31St = LocalDateTime.FromDateTime(dotNetJanuary31St);

            var dotNetDateResult = dotNetJanuary31St.AddMonths(1);
            var nodaTimeDateResult = nodaTimeJanuary31St + Period.FromMonths(1);

            nodaTimeDateResult.Date.Year.Should().Equal(dotNetDateResult.Year);
            nodaTimeDateResult.Date.Month.Should().Equal(dotNetDateResult.Month);
            nodaTimeDateResult.Date.Day.Should().Equal(dotNetDateResult.Day); //GREAT SCOTT! February 28th (Not 31st)
        }

        [Fact]
        public void Add_day_to_february_28th_on_leap_year_to_be_february_29th()
        {
            const string february28Th = "2/28/2016 12:00:00 AM";
            var dotNetFebruary28Th = DateTime.Parse(february28Th);
            var nodaTimeFebruary28Th = LocalDateTime.FromDateTime(dotNetFebruary28Th);

            var dotNetDateResult = dotNetFebruary28Th.AddDays(1);
            var nodaTimeDateResult = nodaTimeFebruary28Th + Period.FromDays(1);

            nodaTimeDateResult.Date.Year.Should().Equal(dotNetDateResult.Year);
            nodaTimeDateResult.Date.Month.Should().Equal(dotNetDateResult.Month);
            nodaTimeDateResult.Date.Day.Should().Equal(dotNetDateResult.Day); //AN ABSOLUTE DREAM! February 29th (Not March 1st)
        }

        [Fact]
        public void Noda_time_zoned_date_time_accounts_for_daylight_saving()
        {
            const string november6Th = "11/6/2016 12:00:00 AM";
            var dotNetNovember6Th = DateTime.Parse(november6Th);

            DateTimeZone easternTimeZone = DateTimeZoneProviders.Tzdb[EasternTimeZoneIdentifier];
            LocalDateTime nodaTimeNovember6Th = LocalDateTime.FromDateTime(dotNetNovember6Th);
            ZonedDateTime before = easternTimeZone.AtStrictly(nodaTimeNovember6Th);

            ZonedDateTime nodaTimeDateResult = before + Duration.FromHours(3);
            DateTime dotNetDateResult = dotNetNovember6Th.AddHours(3);

            nodaTimeDateResult.Date.Year.Should().Equal(dotNetDateResult.Year);
            nodaTimeDateResult.Date.Month.Should().Equal(dotNetDateResult.Month);
            nodaTimeDateResult.Date.Day.Should().Equal(dotNetDateResult.Day);
            nodaTimeDateResult.Hour.Should().Equal(dotNetDateResult.Hour); //Hey McFly, what do you think your doing?!
        }
    }
}
