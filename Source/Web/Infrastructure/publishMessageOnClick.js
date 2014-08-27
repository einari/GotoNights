ko.bindingHandlers.publishMessageOnClick = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var message = ko.utils.unwrapObservable(valueAccessor());
        function publishMessage() {
            Bifrost.messaging.Messenger.global.publish(message);
        }

        return ko.bindingHandlers.click.init(element, function () { return publishMessage; } , allBindingsAccessor, viewModel, bindingContext);
    }
}
