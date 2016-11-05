using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextClustering.Lib
{
    /// <summary>
    /// TODO: generally stop word are removed to make the indexing process effective, We can consider the term as stop words which has highest 
    /// term frequency on document corpus.
    /// </summary>
    public class StopWordsHandler
    {
        //you can defined other stop word list here
        public static string[] stopWordsList = new string[] { "hi","i","me","my","myself","we","us","our","ours","ourselves","you","your","yours","yourself","yourselves","he","him","his","himself","she","her","hers","herself","it","its","itself","they","them","their","theirs","themselves","what","which","who","whom","this","that","these","those","am","is","are","was","were","be","been","being","have","has","had","having","do","does","did","doing","will","would","shall","should","can","could","may","might","must","ought","i'm","you're","he's","she's","it's","we're","they're","i've","you've","we've","they've","i'd","you'd","he'd","she'd","we'd","they'd","i'll","you'll","he'll","she'll","we'll","they'll","isn't","aren't","wasn't","weren't","hasn't","haven't","hadn't","doesn't","don't","didn't","won't","wouldn't","shan't","shouldn't","can't","cannot","couldn't","mustn't","let's","that's","who's","what's","here's","there's","when's","where's","why's","how's","a","an","the","and","but","if","or","because","as","until","while","of","at","by","for","with","about","against","between","into",
"through",
"during",
"before",
"after",
"above",
"below",
"to",
"from",
"up",
"down",
"in",
"out",
"on",
"off",
"over",
"under",
"again",
"further",
"then",
"once",
"here",
"there",
"when",
"where",
"why",
"how",
"all",
"any",
"both",
"each",
"few",
"more",
"most",
"other",
"some",
"such",
"no",
"nor",
"not",
"only",
"own",
"same",
"so",
"than",
"too",
"very",
"one",
"every",
"least",
"less",
"many",
"now",
"ever",
"never",
"say",
"says",
"said",
"also",
"get",
"go",
"goes",
"just","made",
"make",
"put",
"see",
"seen",
"whether",
"like",
"well",
"back",
"even",
"still",
"way",
"take",
"since",
"another",
"however",
"two",
"three",
"four",
"five",
"first",
"second",
"new",
"old",
"high",
"long",
"the"
,"able","about","across","after","all","almost","also","am","among","an","and","any","are","as","at","be","because","been","but","by","can","cannot","could","dear","did","do","does","either","else","ever","every","for","from","get","got","had","has","have","he","her","hers","him","his","how","however","i","if","in","into","is","it","its","just","least","let","like","likely","may","me","might","most","must","my","neither","no","nor","not","of","off","often","on","only","or","other","our","own","rather","said","say","says","she","should","since","so","some","than","that","the","their","them","then","there","these","they","this","tis","to","too","twas","us","wants","was","we","were","what","when","where","which","while","who","whom","why","will","with","would","yet","you","your"};

        public static Boolean IsStotpWord(string word)
        {
            if (stopWordsList.Contains(word, StringComparer.CurrentCultureIgnoreCase))
                return true;
            else
                return false;
        }
    }

}
