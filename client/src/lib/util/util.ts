import { format, type DateArg } from "date-fns";

export function formatdate(date: DateArg<Date>){
    return format(date, 'dd MMM yyyy h:mm a')
}