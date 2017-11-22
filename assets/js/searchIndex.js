
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
        title:"DotNetCoreEfSettings",
        content:"DotNetCoreEfSettings",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"DotNetCoreEfMigrationAddSettings",
        content:"DotNetCoreEfMigrationAddSettings",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"DotNetCoreEfMigrationScripter",
        content:"DotNetCoreEfMigrationScripter",
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
        title:"DotNetCoreEfDatabaseUpdater",
        content:"DotNetCoreEfDatabaseUpdater",
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
        title:"DotNetCoreEfDatabaseDropSettings",
        content:"DotNetCoreEfDatabaseDropSettings",
        description:'',
        tags:''
    });

    a({
        id:7,
        title:"DotNetCoreEfTool",
        content:"DotNetCoreEfTool",
        description:'',
        tags:''
    });

    a({
        id:8,
        title:"DotNetCoreEfMigrationAdder",
        content:"DotNetCoreEfMigrationAdder",
        description:'',
        tags:''
    });

    a({
        id:9,
        title:"DotNetCoreEfMigrationScriptSettings",
        content:"DotNetCoreEfMigrationScriptSettings",
        description:'',
        tags:''
    });

    a({
        id:10,
        title:"ProcessArgumentBuilderExtensions",
        content:"ProcessArgumentBuilderExtensions",
        description:'',
        tags:''
    });

    a({
        id:11,
        title:"DotNetCoreEfContextSettings",
        content:"DotNetCoreEfContextSettings",
        description:'',
        tags:''
    });

    a({
        id:12,
        title:"DotNetCoreEfDatabaseDropper",
        content:"DotNetCoreEfDatabaseDropper",
        description:'',
        tags:''
    });

    a({
        id:13,
        title:"DotNetCoreEfMigrationRemoveSettings",
        content:"DotNetCoreEfMigrationRemoveSettings",
        description:'',
        tags:''
    });

    a({
        id:14,
        title:"DotNetCoreEfMigrationRemover",
        content:"DotNetCoreEfMigrationRemover",
        description:'',
        tags:''
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf/DotNetCoreEfSettings',
        title:"DotNetCoreEfSettings",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf.Migration/DotNetCoreEfMigrationAddSettings',
        title:"DotNetCoreEfMigrationAddSettings",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf.Migration/DotNetCoreEfMigrationScripter',
        title:"DotNetCoreEfMigrationScripter",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf/DotNetCoreEfAliases',
        title:"DotNetCoreEfAliases",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf.Database/DotNetCoreEfDatabaseUpdater',
        title:"DotNetCoreEfDatabaseUpdater",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf.Database/DotNetCoreEfDatabaseUpdateSettings',
        title:"DotNetCoreEfDatabaseUpdateSettings",
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
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf.Migration/DotNetCoreEfMigrationAdder',
        title:"DotNetCoreEfMigrationAdder",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf.Migration/DotNetCoreEfMigrationScriptSettings',
        title:"DotNetCoreEfMigrationScriptSettings",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf/ProcessArgumentBuilderExtensions',
        title:"ProcessArgumentBuilderExtensions",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf/DotNetCoreEfContextSettings',
        title:"DotNetCoreEfContextSettings",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf.Database/DotNetCoreEfDatabaseDropper',
        title:"DotNetCoreEfDatabaseDropper",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf.Migration/DotNetCoreEfMigrationRemoveSettings',
        title:"DotNetCoreEfMigrationRemoveSettings",
        description:""
    });

    y({
        url:'/Cake.DotNetCoreEf/Cake.DotNetCoreEf/api/Cake.DotNetCoreEf.Migration/DotNetCoreEfMigrationRemover',
        title:"DotNetCoreEfMigrationRemover",
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
