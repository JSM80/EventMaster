export class Event {
  eventTitle?: string;
  eventData?: number;
  eventAddress?: string;
}

export class ResponseDto<T> {
  responseData?: T;
  messageToClient?: string
}
