using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ServiceModel.Syndication;

namespace FestivalSSA.Controllers
{
    public class RssFeedController : ApiController
    {
        public Rss20FeedFormatter GetFeed()
        {
            var feed = new SyndicationFeed("My RSS Feed (Made by Peter VandenKerckhove)", "RSS Feed festival", new Uri("http://localhost:1079/api/rssfeed"));
            feed.Authors.Add(new SyndicationPerson("peter.vandenkerckhove@student.howest.be"));
            feed.Categories.Add(new SyndicationCategory("Festival SSA"));
            feed.Description = new TextSyndicationContent("Dit is een RSS Feed van het festivalproject voor het vak Server Side Applications");

            SyndicationItem item1 = new SyndicationItem(
                "Eminem",
                "Vrijwel iedereen kent deze superster uit de hiphopwereld nog van de tijd dat hij nog bekend stond als The Real Slim Shady. Voor degenen die het nog niet weten: zijn echt naam is Marshall Bruce Mathers. Hij staat bekend om zijn controversiële teksten en het feit dat hij blank is (wat toentertijd weinig voorkwam in de wereld van de hiphop).",
                new Uri("http://localhost:1079/Home/Details/21"),
                "Eminem",
                DateTime.Now);

            SyndicationItem item2 = new SyndicationItem(
                "James Arthur",
                "James Arthur won in 2012 X-factor in Engeland. Met zijn debuutsingle 'Impossible', een cover van Shontelle, scoorde hij meteen een nummer 1 hit in zijn thuisland.",
                new Uri("http://localhost:1079/Home/Details/10"),
                "JamesArthur",
                DateTime.Now);
            SyndicationItem item3 = new SyndicationItem(
                "Justin Timberlake",
                "All-time hunk en gedoodverfde nieuwe King Of Pop Justin Randall Timberlake werd bekend als lid van de boysband *NSYNC en gaat sinds 2002 als soloartiest door het leven. 'Justified' was zijn debuutplaat en het nummer 'Like I Love You' de eerste hitsingle. Zjin sterrenstatus breidde zich stilaan uit en bereikte met het door Timbaland geproduceerde FutureSex/LoveSounds ongeziene hoogtes. 'Sexyback', 'Lovestoned', 'Ayo Technology', '4 minutes', het lijstje hits werd steeds langer en langer. ",
                new Uri("http://localhost:1079/Home/Details/3"),
                "JustinTimberlake",
                DateTime.Now);
            SyndicationItem item4 = new SyndicationItem(
                "Ed Sheeran",
                "Edward Christopher Sheeran droomt van een Lego huisje waarin hij zijn geliefde kan beschermen en de brokken die hij maakt simpelweg opnieuw op elkaar kan zetten. Sheeran speelt al sinds zijn jeugd gitaar en begon al snel muziek te schrijven. Om bekend te worden ging hij niet uit de kleren, kwam hij niet in het nieuws door een alcoholverslaving, won hij geen talentenjacht maar trad hij, heel ouderwets lijkt het bijna, heel veel op. In 2009 gaf hij maar liefst 312 optredens. Hij trok naar de VS en ontmoette er Jamie Foxx, met wie hij enkele nummers opnam. In 2010 begon zijn harde werk eindelijk te lonen. Wanneer ook Elton John, voetballer Rio Ferdinand en Jools Holland hem ontdekten schoot zijn carrière plots helemaal uit de startblokken. Zijn eerste internationale hit werd 'Lego House'.",
                new Uri("http://localhost:1079/Home/Details/22"),
                "EdSheeran",
                DateTime.Now);


            List<SyndicationItem> list = new List<SyndicationItem>();
            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            list.Add(item4);

            feed.Items = list;

            return new Rss20FeedFormatter(feed);
        }
    }
}
