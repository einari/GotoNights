Bifrost.namespace("Web.Configuration", {
    Hub: Bifrost.Type.extend(function (targetHub) {
        var self = this;

        this.targetHub = targetHub;

        this.server = targetHub.server;
        this.client = {};

        this.addClientFunction = function (method) {
            self.targetHub.client[method] = function () {
                for (var callbackIndex = 0; callbackIndex < self.client[method].callbacks.length; callbackIndex++) {
                    var callback = self.client[method].callbacks[callbackIndex];
                    callback.apply(this, arguments);
                }
            }
            self.client[method] = function (callback) {
                self.client[method].callbacks.push(callback);
            }
            self.client[method].callbacks = [];
        };
    }),

    HubsDependencyResolver: Bifrost.Type.extend(function () {
        var self = this;
        this.hubs = Web.Configuration.HubsDependencyResolver.hubs;
        this.isConnected = false;

        this.connectedCallbacks = [];


        this.canResolve = function (namespace, name) {
            return self.hubs.hasOwnProperty(name);
        };
        this.resolve = function (namespace, name) {
            if (self.isConnected == false) {
                var promise = Bifrost.execution.Promise.create();
                var hubName = name;
                this.connectedCallbacks.push(function () {
                    promise.signal(self.hubs[name]);
                });
                return promise;
            }
            return self.hubs[name];
        };

        this.signalConnected = function () {
            self.isConnected = true;
            $.each(self.connectedCallbacks, function (index, callback) {
                callback();
            });

        };
    })
});

Bifrost.namespace("Web.Configuration", {
    employeeHub: Web.Configuration.Hub.extend(function(targetHub) {
        this.addClientFunction("hired");
    })
    /*
    GameHub: Web.Configuration.Hub.extend(function (targetHub) {
        var self = this;

        this.addClientFunction("added");
        this.addClientFunction("deleted");
        this.addClientFunction("saved");
    }),
    TeamHub: Web.Configuration.Hub.extend(function (targetHub) {
        var self = this;

        this.addClientFunction("loggedIn");
        this.addClientFunction("loggedOut");
    }),
    QuestionHub: Web.Configuration.Hub.extend(function (targetHub) {
        var self = this;
    }),
    GameplayHub: Web.Configuration.Hub.extend(function (targetHub) {
        var self = this;

        this.addClientFunction("started");
        this.addClientFunction("stopped");
        this.addClientFunction("stateChanged");
        this.addClientFunction("currentQuestionGroupChanged");
        this.addClientFunction("showBlankPage");
        this.addClientFunction("showQuestions");
        this.addClientFunction("disableDeliverButton");
    }),
    AnswerHub: Web.Configuration.Hub.extend(function (targetHub) {
        var self = this;

        this.addClientFunction("delivered");
    }),
    GraphicsHub: Web.Configuration.Hub.extend(function (targetHub) {
        var self = this;

        this.addClientFunction("commandSent");
        this.addClientFunction("statusChanged");
    }),
    ConfigurationHub: Web.Configuration.Hub.extend(function (targetHub) {
        var self = this;
    }),
    LoggerHub: Web.Configuration.Hub.extend(function (targetHub) {
        var self = this;

        this.addClientFunction("entryAdded");
    })*/
});

Web.Configuration.HubsDependencyResolver.hubs = {
    employeeHub: Web.Configuration.employeeHub.create({ targetHub: $.connection.employeeHub })
    /*
    gameHub: Web.Configuration.GameHub.create({ targetHub: $.connection.gameHub }),
    teamHub: Web.Configuration.TeamHub.create({ targetHub: $.connection.teamHub }),
    questionHub: Web.Configuration.QuestionHub.create({ targetHub: $.connection.questionHub }),
    gameplayHub: Web.Configuration.GameplayHub.create({ targetHub: $.connection.gameplayHub }),
    answerHub: Web.Configuration.AnswerHub.create({ targetHub: $.connection.answerHub }),
    graphicsHub: Web.Configuration.GraphicsHub.create({ targetHub: $.connection.graphicsHub }),
    configurationHub: Web.Configuration.ConfigurationHub.create({ targetHub: $.connection.configurationHub }),
    loggerHub: Web.Configuration.LoggerHub.create({ targetHub: $.connection.loggerHub })*/
};
Bifrost.dependencyResolvers.hubs = Web.Configuration.HubsDependencyResolver.create();

$.connection.hub.start().done(function () {
    if (typeof console !== "undefined") {
        console.log("Hubs are connected");
    }

    Bifrost.dependencyResolvers.hubs.signalConnected();
});