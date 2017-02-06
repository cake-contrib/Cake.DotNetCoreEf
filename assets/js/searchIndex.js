
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"DotNetCoreEfDatabaseUpdater",
        content:"DotNetCoreEfDatabaseUpdater",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"DotNetCoreEfDatabaseDropSettings",
        content:"DotNetCoreEfDatabaseDropSettings",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"DotNetCoreEfTool",
        content:"DotNetCoreEfTool",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"DotNetCoreEfAliases",
        content:"DotNetCoreEfAliases",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"DotNetCoreEfSettings",
        content:"DotNetCoreEfSettings",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"DotNetCoreEfDatabaseUpdateSettings",
        content:"DotNetCoreEfDatabaseUpdateSettings",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"DotNetCoreEfDatabaseDropper",
        content:"DotNetCoreEfDatabaseDropper",
        description:'',
        tags:''
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf.Database/DotNetCoreEfDatabaseUpdater',
        title:"DotNetCoreEfDatabaseUpdater",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf.Database/DotNetCoreEfDatabaseDropSettings',
        title:"DotNetCoreEfDatabaseDropSettings",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf/DotNetCoreEfTool_1',
        title:"DotNetCoreEfTool<TSettings>",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf/DotNetCoreEfAliases',
        title:"DotNetCoreEfAliases",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf/DotNetCoreEfSettings',
        title:"DotNetCoreEfSettings",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf.Database/DotNetCoreEfDatabaseUpdateSettings',
        title:"DotNetCoreEfDatabaseUpdateSettings",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf.Database/DotNetCoreEfDatabaseDropper',
        title:"DotNetCoreEfDatabaseDropper",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
