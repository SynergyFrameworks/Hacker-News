import { Pipe, PipeTransform } from '@angular/core';
import {Item} from './Item';

@Pipe({
  name: 'hacker-filter'
})
export class HackerFilterPipe implements PipeTransform {


  transform(news: Item[], itemfilter: string) {
    return news.filter(item => item.type === itemfilter);
}

}
