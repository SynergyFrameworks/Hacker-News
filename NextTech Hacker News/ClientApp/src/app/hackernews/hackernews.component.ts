import { Component, OnInit } from '@angular/core';
import { HackerNewsService } from '../service/hackernews.service';
import { Subject, BehaviorSubject, combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-hacker-news',
  templateUrl: './hackernews.component.html',
  styleUrls: ['./hackernews.component.scss']
})
export class HackerNewsComponent implements OnInit {

  pageTitle = 'Hacker News List';
  private errorMessageSubject = new Subject<string>();
  errorMessage$ = this.errorMessageSubject.asObservable();

  private newsSelectedSubject = new BehaviorSubject<number>(0);
  newSelectedAction$ = this.newsSelectedSubject.asObservable();

/*   news$ = combineLatest([
    this.hackerNewsService.selectedNews$,
    this.newSelectedAction$
  ])
    .pipe(
      // map(([news, selectedNewsId]) =>
      //   news.filter(news =>
      //     selectedNewsId ? news.id === selectedNewsId : true
      //   )),
      // catchError(err => {
      //   this.errorMessageSubject.next(err);
      //   return EMPTY;
      // })
    ); */



  constructor( private hackerNewsService: HackerNewsService) { }

  ngOnInit() {
  }

  onSelected(newsId: string): void {
    this.newsSelectedSubject.next(+newsId);
  }

}
