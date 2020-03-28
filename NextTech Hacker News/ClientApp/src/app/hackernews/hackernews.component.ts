import { Component, OnInit } from '@angular/core';
import { HackerNewsService } from '../service/hackernews.service';
import { Subject, BehaviorSubject, combineLatest, EMPTY } from 'rxjs';
import { map, catchError } from 'rxjs/operators';


@Component({
  selector: 'app-hacker-news',
  templateUrl: './hackernews.component.html',
  styleUrls: ['./hackernews.component.scss']
})
export class HackerNewsComponent implements OnInit {

  pageTitle = 'Hacker News';
  private errorMessageSubject = new Subject<string>();
  errorMessage$ = this.errorMessageSubject.asObservable();

  private newsSelectedSubject = new BehaviorSubject<number>(0);
  newSelectedAction$ = this.newsSelectedSubject.asObservable();
    counter: number;
  news$ = combineLatest([
    this.hackerNewsService.hackerNews$,
    this.newSelectedAction$
  ])
    .pipe(
      map(([news, selectedNewsId]) =>
        news.filter(newsx =>
          selectedNewsId ? newsx.id === selectedNewsId : true
        )),
      catchError(err => {
        this.errorMessageSubject.next(err);
        return EMPTY;
      })
    );



  constructor( private hackerNewsService: HackerNewsService) { }

  ngOnInit() {
  }

  onSelected(newsId: string): void {
    this.newsSelectedSubject.next(+newsId);
  }

}
