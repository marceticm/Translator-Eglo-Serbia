using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prevod_za_carinu
{
    class Prevodi
    {
        public static string PrevodPoOpisu(string opis)
        {
            if (opis.Contains("LM-") || opis.Contains("bulb")) return "sijalica";
            else if (opis.Contains("LS/") || opis.Contains("BALKEN/") || 
                opis.Contains("RONDELL") || opis.Contains("G-FORM") || 
                opis.Contains("-light") || opis.Contains("G-form")) return "spot lampa";
            else if (opis.Contains("HL-") || opis.Contains("HL/") || 
                opis.Contains("-HL") || opis.Contains("HL ")) return "visilica";
            else if (opis.Contains("STL/") || opis.Contains("-STL") || 
                opis.Contains("FL/") || opis.Contains("FL ")) return "podna lampa";
            else if (opis.Contains("TL/") || opis.Contains("-TL") || 
                opis.Contains("TL-") || opis.Contains("TL ")) return "stona lampa";
            else if (opis.Contains("WL/DL") || opis.Contains("WELLE/") || opis.Contains("wave") ||
                opis.Contains("QUADRAT") || opis.Contains("square") || 
                opis.Contains("WL/CL")) return "zidna lampa/plafonjera";
            else if (opis.Contains("WL/") || opis.Contains("WL ") || 
                opis.Contains("-WL") || opis.Contains("-SPIEGELL") ||
                opis.Contains("-mirror") || opis.Contains("SPIEGELLEUCHTE/")) return "zidna lampa";
            else if (opis.Contains("SALOBRENA")) return "led panel";
            else if (opis.Contains("DL/") || opis.Contains("-DL") || 
                opis.Contains("-CL") || opis.Contains("CL ") || 
                opis.Contains("CL/") || opis.Contains("DL ")) return "plafonjera";
            else if (opis.Contains("Description")) return "Prevod";
            else if (opis.Contains("EINBAU") || opis.Contains("rec") || 
                opis.Contains("REC") || opis.Contains("wall-fitting")) return "ugradna svetiljka";
            else if (opis.Contains("DIMMER")) return "potenciometar za lampu";
            else if (opis.Contains("LED-BAND") || opis.Contains("LED-stripe") ||
                opis.Contains("LED-STRIPE") || opis.Contains("LED-BLE-STRIPE")) return "led traka";
            else if (opis.Contains("FERNBEDIENUNG")) return "daljinski upravljač";
            else if (opis.Contains("SCHIRM") || opis.Contains("shade") || opis.Contains("Shade")) return "abažur";
            else if (opis.Contains("LED-DRIVER") || opis.Contains("LED-driver")) return "led napajanje";
            else if (opis.Contains("PALETTE")) return "paleta";
            else if (opis.Contains("STRAHLER") || opis.Contains("spotlight")) return "reflektor";
            else if (opis.Contains("HOLZLAMELLE") || opis.Contains("wood-rib")) return "drveni rezervni deo";
            else if (opis.Contains("HOLZRING")) return "rezervni prsten";
            else if (opis.Contains("LED-PLATINE") || opis.Contains("platine")) return "led ploča";
            else if (opis.Contains("AUFBAU")) return "nadgradna svetiljka";
            else if (opis.Contains("ADAPTER")) return "adapter za rasvetu";
            else if (opis.Contains("STECKDOSENSPOT") || opis.Contains("plug-in lamp")) return "lampa za utičnicu";
            else if (opis.Contains("STROMSCHIENE")) return "šina za rasvetu";
            else if (opis.Contains("SOLAR-")) return "solarna lampa";
            else return "";
        }

        public static string PrevodPoSifri(string sifra)
        {
            if (sifra.Contains("GL")) return "rezervno staklo";
            else return "";
        }
    }
}
