namespace ProjectB.Services {

    export class EventService {
        private eventResources;

        constructor(private $resource: angular.resource.IResourceService) {
            this.eventResources = $resource("api/danceEvent/:id", null, {
                getPhotographersByDanceEvent: {
                    method: 'GET',
                    url: '/api/danceEvent/getPhotographersByDanceEvent/:id',
                    isArray: true
                }
            });
        }

        public getDanceEvents() {
            return this.eventResources.query();
        }

        public getDanceEvent(id) {
            return this.eventResources.get({ id: id })
        }

        public getPhotographersByDanceEvent(id) {
            return this.eventResources.getPhotographersForEvent({ id: id });
        }

        public saveEvent(eventSave) {
            return this.eventResources.save(eventSave).$promise;
        }


        public deleteEvent(id) {
            return this.eventResources.delete({ id: id }).$promise;
        }

    }
    angular.module("ProjectB").service("eventService", EventService);
}