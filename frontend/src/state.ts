import {Injectable} from "@angular/core";
import {Event} from "./models";

@Injectable({
  providedIn: 'root'
})

export class State {
  events: Event[] =[
    { eventTitle: 'Event 1', eventData: 152, eventAddress: 'Location 1' },
    { eventTitle: 'Event 2', eventData: 482, eventAddress: 'Location 2' },
    { eventTitle: 'Event 3', eventData: 528, eventAddress: 'Location 3' },
    { eventTitle: 'Event 4', eventData: 756, eventAddress: 'Location 4' },
    { eventTitle: 'Event 5', eventData: 528, eventAddress: 'Location 5' },
    { eventTitle: 'Event 6', eventData: 756, eventAddress: 'Location 6' },
  ];
  editEvent: Event = {}

}
