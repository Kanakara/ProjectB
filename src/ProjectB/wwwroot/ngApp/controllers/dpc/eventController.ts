namespace ProjectB.Controllers {

    export class EventController {
        public events;
        public event;
        public users;

        constructor(private eventService: ProjectB.Services.EventService,
            private $uibModal: angular.ui.bootstrap.IModalService) {
            this.getDanceEvents();
        }
        //public showCreateModal(eventId: number) {
        //    this.$uibModal.open({
        //        templateUrl: "/ngApp/views/eventCreate.html",
        //        controller: ProjectB.Controllers.EventCreateModalController,
        //        controllerAs: "controller",
        //        resolve: { eventId: () => eventId },
        //        size: "sm"
        //    });
        //}
        //public showDeleteModal(eventId: number) {
        //    this.$uibModal.open({
        //        templateUrl: "/ngApp/views/eventDelete.html",
        //        controller: ProjectB.Controllers.EventDeleteModalController,
        //        controllerAs: "controller",
        //        resolve: { eventId: () => eventId },
        //        size: "sm"
        //    });
        //}
        //public showEditModal(eventId: number) {
        //    this.$uibModal.open({
        //        templateUrl: "/ngApp/views/eventEdit.html",
        //        controller: ProjectB.Controllers.EventEditModalController,
        //        controllerAs: "controller",
        //        resolve: { eventId: () => eventId },
        //        size: "sm"
        //    });
        //}
        private getDanceEvents() {
            this.events = this.eventService.getDanceEvents();
        }
        public show(event, id) {
            this.event = event;
            this.users = this.eventService.getPhotographersByDanceEvent(id);
        }
        //public isLoggedIn() {
        //    return this.accountService.isLoggedIn();
        //}
    }
}