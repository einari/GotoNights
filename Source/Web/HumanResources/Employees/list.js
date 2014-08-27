Bifrost.namespace("Web.HumanResources.Employees", {
    list: Bifrost.views.ViewModel.extend(function (employees, employeeHub, mapper) {
        var self = this;
        this.employees = employees.all();

        employeeHub.client.hired(function (employee) {
            employee = mapper.map(employees.readModel, employee);
            self.employees.push(employee);
        });
    })
});