import { Providers } from './providers';
import './global.css';

export const metadata = {
  title: 'StageLab',
  description: 'Opera production planning',
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body>
        <Providers>{children}</Providers>
      </body>
    </html>
  );
}
