import {
  NotificationsNoneIcon,
  HelpOutlineIcon,
  SearchIcon,
  TheaterComedyIcon,
} from '@/app/components/Icons';
import { auth } from '@/auth';
import { getUserEvents } from '@/lib/api';

export default async function ProtectedLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const session = await auth();
  console.log(session)

  let events: Array<{ description: string; id: number; }> | undefined;
  if (session?.accessToken != null && session.user?.id != null) {
    events = await getUserEvents(session.accessToken, session.user.id);
    console.log(events)

  }

  return (
    <div className="flex h-screen w-full">
      <aside className="sidebar flex">
        <div className="m-4 flex-1 flex flex-col justify-between">
          <div className="flex items-center gap-4">
            <div className="size-10 bg-primary flex items-center justify-center rounded-lg text-slate-100">
              <TheaterComedyIcon className="size-8"></TheaterComedyIcon>
            </div>
            <h1 className="text-2xl font-bold text-slate-900 tracking-tight">
              StageLab
            </h1>
          </div>
          <div className="bg-white/50 rounded-xl w-full h-20">
            {children}
          </div>
        </div>
      </aside>
      <div className="flex flex-col flex-1 h-full">
        <header className="top-bar flex px-8">
          <div className="flex flex-1 items-center">
            <div className="relative w-full max-w-xl">
              <SearchIcon className="size-5 text-slate-400 absolute left-3 top-1/5"></SearchIcon>
              <input
                className="w-full bg-slate-100 border-none rounded-lg py-2 pl-10 pr-4 text-sm focus:ring-2 focus:ring-primary placeholder:text-slate-400"
                placeholder="Search events, people, or productions..."
              />
            </div>
          </div>
          <div className="flex items-center gap-4 align-end">
            <button className="size-10 flex items-center justify-center rounded-lg bg-slate-100 text-slate-600 hover:bg-slate-200 transition-colors cursor-pointer">
              <NotificationsNoneIcon className="size-6"></NotificationsNoneIcon>
            </button>
            <button className="size-10 flex items-center rounded-lg justify-center bg-slate-100 text-slate-600 hover:bg-slate-200 transition-colors cursor-pointer">
              <HelpOutlineIcon className="size-6 "></HelpOutlineIcon>
            </button>
          </div>
        </header>
        <div className="flex-1 min-h-0 overflow-y-auto m-5">
          {events != null && events.length > 0 && (
            events.map(event => <div key={event.id.toString()}>{event.description}</div>)
          )}
        </div>
      </div>
    </div>
  );
}