import { auth } from '@/auth';
import CalendarSection from './components/calendar/CalendarSection';

export default async function Home() {
  const session = await auth();

  return (
    <main className="p-6 h-full flex flex-col">
      <div className="mb-6 shrink-0">
        <h1 className="text-2xl font-bold text-slate-900 tracking-tight">
          Welcome back, {session?.user?.name || session?.user?.email}
        </h1>
        <p className="text-slate-500 mt-1">Here&apos;s your schedule overview</p>
      </div>

      <CalendarSection />
    </main>
  );
}