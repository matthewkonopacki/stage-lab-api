import Sidebar from '@/app/(protected)/components/sidebar/Sidebar';
import Header from '@/app/(protected)/components/header/Header';

export default async function ProtectedLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <div className="flex h-screen w-full">
      <Sidebar />
      <div className="flex flex-col flex-1 h-full">
        <Header />
        <div className="flex-1 min-h-0 overflow-y-auto">{children}</div>
      </div>
    </div>
  );
}
