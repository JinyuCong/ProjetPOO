using System.Globalization;

namespace HearthstoneCollections;

public class LocalizationService
{
    private Dictionary<string, Dictionary<string, string>> data;
    private string currentLanguage = CultureInfo.CurrentCulture.Name.Split("-")[0];

    public LocalizationService()
    {
        data = new Dictionary<string, Dictionary<string, string>>()
        {
            {
                "zh", new Dictionary<string, string>()
                {
                    {"msg.DiscoverCard", $"卡牌已发现："},
                    {"msg.SaveXml", $"XML文件保存成功到路径："},
                    {"msg.SaveTsv", $"TSV文件保存成功到路径："},
                    {"msg.ArgumentNotEnough", $"没有足够的参数"},
                    {"msg.ParsingError", $"卡牌变更错误："},
                    {"msg.CardAdded", $"卡牌已添加："},
                    {"msg.CardNotFount", $"卡牌不存在："},
                    {"msg.CommandRequiesArgument", $"命令行需要至少一个参数"},
                    {"msg.CommandUnknown", $"命令不存在："},
                    {"msg.CardNumber", $"职业的卡牌数量为："},
                    {"msg.PathNotFound", $"路径不存在"},
                    {"msg.FileFormatInvalid", $"输入文件格式不正确"},
                    {"msg.LineFormatInvalid", $"文件行格式不正确："},
                    {"msg.LoadCardsSuccesful", $"卡牌录入成功，现有卡牌数："},
                    {"msg.LanguageNotSupport", $"语言不支持："},
                    {"msg.LanguageChanged", $"语言已变更为中文"},
                    {"msg.DuplicateCard", "卡牌已重复："},
                    {"msg.CardWin", "胜出者："},
                    {"msg.NoWinner", "没有胜出者"},
                    
                    //helps
                    {"msg.AddHelp", $"add 或 ajouter 命令使用说明:\n" +
                                    $"使用 'add <名称> <稀有度> <类型> <文本> <攻击力> <生命值> <法力值消耗> <职业> <是否发现>' 来将一张卡牌添加到收藏中\n" +
                                    $"例如: add Ragnaros legendary minion \"(必须用双引号包裹文本)\" 8 8 8 Neutral true\n"},
                    
                    {"msg.SearchHelp", $"search 或 rechercher 命令使用说明:\n" +
                                       $"使用 \"search <卡牌名称>\" 指定卡牌名称并显示其信息。\n" +
                                       $"或者使用 \"search <职业>\" 来显示指定职业的所有卡牌。\n" +
                                       $"例如: \"search mage\" 将显示所有法师职业的卡牌。\n" +
                                       $"\"search ice block\" 将显示卡牌 'ice block' 的信息。\n"},
                    
                    {"msg.DiscoverHelp", $"discover 或 découvrir 命令使用说明:\n" +
                                         $"使用 \"discover <卡牌名称>*\" 将指定的卡牌设置为已发现。\n" +
                                         $"例如: discover ragnaros \"ice block\"\n" +
                                         $"此命令可以一次性发现多张卡牌。\n"},
                    
                    {"msg.LoadHelp", $"load 或 charger 命令使用说明:\n" +
                                     $"使用 \"load <文件路径>\" 从指定文件加载卡牌信息到收藏中。\n" +
                                     $"例如: \"load data/test.csv\" 将从 data/test.csv 加载卡牌信息。\n" +
                                     $"注意: 文件内容必须以制表符分隔。\n"},
                    
                    {"msg.LoadxmlHelp", $"loadxml 或 chargerxml 命令使用说明:\n" +
                                        $"使用 \"loadxml <文件路径>\" 从指定路径加载卡牌信息到收藏中。\n" +
                                        $"例如: \"loadxml data/CardData.xml\" 将从 CardData.xml 加载所有卡牌信息到收藏中。\n"},
                    
                    {"msg.SaveHelp", $"save 或 enregistrer 命令使用说明:\n" +
                                     $"\"save <文件名>\" 将已发现的卡牌保存到 data/<文件名>。\n" +
                                     $"或者使用 'save <文件名>.txt' 或 'save <文件名>.tsv' 将已发现的卡牌保存为 .txt 或 .tsv 文件。\n"},
                    
                    {"msg.SavexmlHelp", $"savexml 或 enregistrerxml 命令使用说明:\n" +
                                        $"使用 savexml <保存路径> 将收藏中的卡牌信息保存到指定路径。\n" +
                                        $"例如: \"savexml test.xml\" 或 \"save test\"。\n"},
                    
                    {"msg.SwitchHelp", $"switch 或 changer 命令使用说明:\n" +
                                       $"使用 \"switch fr\" 或 \"switch zh\" 来切换到法语或中文。\n"},
                    
                    {"msg.CountHelp", $"count 或 compter 命令使用说明:\n" +
                                      $"使用 \"count all\" 或 \"count <职业>\" 来统计所有职业或指定职业的卡牌数量。\n" +
                                      $"例如: \"count all\" 将统计收藏中所有卡牌的数量。\n" +
                                      $"\"count mage\" 将统计法师职业的卡牌数量。\n"},
                    
                    {"msg.BattleHelp", $"battle 或 battre 命令使用说明：\n" +
                                       $"使用 \"battle <card name 1> <card name 2>\" 来判断两个随从的胜负，如果一个随从死亡则另一个随从胜利，" +
                                       $"如果两个随从都死亡或存活，则没有胜者。\n" +
                                       $"例如: battle \"Goldshire Footman\" \"River Crocolisk\""},
                    
                    {"msg.ExitHelp", $"exit 或 quitter 命令使用说明:\n" +
                                     $"使用 \"exit\" 退出程序。\n"},
                    
                    {"msg.HelpHelp", $"help 或 aide 命令使用说明:\n" +
                                     $"使用 \"help\" 来显示此信息。\n"},
                }
            },
            {
                "fr", new Dictionary<string, string>()
                {
                    {"msg.DiscoverCard", $"Carte découverte : "},
                    {"msg.SaveXml", $"Fichier XML enregistré avec succès dans le chemin : "},
                    {"msg.SaveTsv", $"Fichier TSV enregistré avec succès dans le chemin : "},
                    {"msg.ArgumentNotEnough", $"Pas assez d'arguments"},
                    {"msg.ParsingError", $"Erreur de modification de carte : "},
                    {"msg.CardAdded", $"Carte ajoutée : "},
                    {"msg.CardNotFount", $"Carte introuvable : "},
                    {"msg.CommandRequiesArgument", $"La commande nécessite au moins un argument"},
                    {"msg.CommandUnknown", $"Commande inconnue : "},
                    {"msg.CardNumber", $"Nombre de cartes pour la classe : "},
                    {"msg.PathNotFound", $"Chemin introuvable"},
                    {"msg.FileFormatInvalid", $"Format de fichier d'entrée incorrect"},
                    {"msg.LineFormatInvalid", $"Format de ligne de fichier incorrect : "},
                    {"msg.LoadCardsSuccesful", $"Cartes chargées avec succès, nombre de cartes dans la collectiom : "},
                    {"msg.LanguageNotSupport", $"Langue non supporte : "},
                    {"msg.LanguageChanged", $"Langue est en français"},
                    {"msg.DuplicateCard", "Carte déjà existe : "},
                    {"msg.CardWin", "Gagnant : "},
                    {"msg.NoWinner", "Pas de gagnant"},
                    
                    //helps
                    {"msg.AddHelp", $"add ou ajouter instructions de commande:\n" +
                                    $"Utilisez 'add <nom> <rare> <type> <texte> <attaque> <vie> <coût> <classe> <découvert>' pour ajouter une carte à la collection.\n" +
                                    $"Par exemple: add Ragnaros legendary minion \"(le texte doit être entre guillemets)\" 8 8 8 Neutral true\n"},

                    {"msg.SearchHelp", $"search ou rechercher instructions de commande:\n" +
                                       $"Utilisez \"search <nom de carte>\" pour spécifier un nom de carte et afficher ses informations.\n" +
                                       $"Ou utilisez \"search <classe>\" pour afficher toutes les cartes de la classe spécifiée.\n" +
                                       $"Par exemple: \"search mage\" affichera toutes les cartes de la classe mage.\n" +
                                       $"\"search ice block\" affichera les informations de la carte 'ice block'.\n"},

                    {"msg.DiscoverHelp", $"discover ou découvrir instructions de commande:\n" +
                                         $"Utilisez \"discover <nom de carte>*\" pour définir les cartes spécifiées comme découvertes.\n" +
                                         $"Par exemple: discover ragnaros \"ice block\"\n" +
                                         $"Cette commande permet de découvrir plusieurs cartes en même temps.\n"},

                    {"msg.LoadHelp", $"load ou charger instructions de commande:\n" +
                                     $"Utilisez \"load <chemin du fichier>\" pour charger les informations des cartes dans la collection à partir du fichier spécifié.\n" +
                                     $"Par exemple: \"load data/test.csv\" pour charger les informations des cartes à partir de data/test.csv.\n" +
                                     $"Attention : le contenu du fichier doit être séparé par des tabulations.\n"},

                    {"msg.LoadxmlHelp", $"loadxml ou chargerxml instructions de commande:\n" +
                                        $"Utilisez \"loadxml <chemin du fichier>\" pour charger les informations des cartes dans la collection depuis le chemin spécifié.\n" +
                                        $"Par exemple: \"loadxml data/CardData.xml\" pour charger toutes les informations des cartes dans CardData.xml dans la collection.\n"},

                    {"msg.SaveHelp", $"save ou enregistrer instructions de commande:\n" +
                                     $"\"save <nom du fichier>\" pour enregistrer les cartes découvertes dans data/<nom du fichier>.\n" +
                                     $"Ou utilisez 'save <nom du fichier>.txt' ou 'save <nom du fichier>.tsv' pour enregistrer les cartes découvertes dans un fichier .txt ou .tsv.\n"},

                    {"msg.SavexmlHelp", $"savexml ou enregistrerxml instructions de commande:\n" +
                                        $"Utilisez savexml <chemin de sauvegarde> pour enregistrer les informations des cartes de la collection dans le chemin spécifié.\n" +
                                        $"Par exemple: \"savexml test.xml\" ou \"save test\".\n"},

                    {"msg.SwitchHelp", $"switch ou changer instructions de commande:\n" +
                                       $"Utilisez \"switch fr\" ou \"switch zh\" pour changer la langue en français ou en chinois.\n"},

                    {"msg.CountHelp", $"count ou compter instructions de commande:\n" +
                                      $"Utilisez \"count all\" ou \"count <classe>\" pour compter le nombre de cartes de toutes les classes ou d'une classe spécifiée.\n" +
                                      $"Par exemple: \"count all\" comptera le nombre total de cartes dans la collection.\n" +
                                      $"\"count mage\" comptera le nombre de cartes de la classe mage.\n"},
                    
                    {"msg.BattleHelp", $"battle ou battre instructions de commande：\n" +
                                       $"Utilisez \"battle <card name 1> <card name 2>\" pour déterminer le gagnant entre deux serviteurs. Si un serviteur meurt, l'autre est déclaré vainqueur, " +
                                       $"et si les deux serviteurs meurent ou survivent, il n'y a pas de gagnant.\n" +
                                       $"Par exemple : battle \"Goldshire Footman\" \"River Crocolisk\""},
                    
                    {"msg.ExitHelp", $"exit ou quitter instructions de commande:\n" +
                                     $"Utilisez \"exit\" pour quitter le programme.\n"},

                    {"msg.HelpHelp", $"help ou aide instructions de commande:\n" +
                                     $"Utilisez \"help\" pour afficher ces informations.\n"}
                }
            }
            
        };
    }

    public string GetMessage(string key)
    {
        return data[currentLanguage][key];
    }

    public void ChangeLanguage(string newLanguage)
    {
        currentLanguage = newLanguage;
    }
}